using AutoMapper;
using ControleDeEstoque.API.Context;
using ControleDeEstoque.API.Domain.Entities;
using ControleDeEstoque.API.Domain.Models;
using ControleDeEstoque.API.Helpers;
using ControleDeEstoque.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using BC = BCrypt.Net.BCrypt;

namespace ControleDeEstoque.API.Services
{
    public class UserService : IUserService
    {
        private DatabaseContext _context;
        private readonly IMapper _mapper;

        public UserService(
        DatabaseContext context,
        IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }

        public async Task AddUserAsync(CreateUserRequest model)
        {
            // validate
            if (_context.Users.Any(x => x.Email == model.Email))
                throw new AppException("User with the email '" + model.Email + "' already exists");

            // map model to new user object
            var user = _mapper.Map<User>(model);

            // hash password
            user.PasswordHash = BC.HashPassword(model.Password);

            // save user
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(Guid id, UpdateUserRequest model)
        {
            var user = await GetUserByIdAsync(id);

            // validate
            if (model.Email != user.Email && _context.Users.Any(x => x.Email == model.Email))
                throw new AppException("User with the email '" + model.Email + "' already exists");

            // hash password if it was entered
            if (!string.IsNullOrEmpty(model.Password))
                user.PasswordHash = BC.HashPassword(model.Password);

            // copy model to user and save
            _mapper.Map(model, user);
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(Guid id)
        {
            await _context.Users.Where(u => u.Id == id).ExecuteDeleteAsync();
        }
    }
}
