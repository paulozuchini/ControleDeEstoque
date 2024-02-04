using AutoMapper;
using ControleDeEstoque.API.Context;
using ControleDeEstoque.API.Domain.Entities;
using ControleDeEstoque.API.Domain.Models;
using ControleDeEstoque.API.Helpers;
using ControleDeEstoque.API.Services.Interfaces;
using BC = BCrypt.Net.BCrypt;

namespace ControleDeEstoque.API.Services
{
    public class UserService : IUserService
    {
        private DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(
        DatabaseContext context,
        IMapper mapper,
        ILogger<UserService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(Guid id)
        {
            return getUser(id);
        }

        public void Create(CreateUserRequest model)
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
            _context.SaveChanges();
        }

        public void Update(Guid id, UpdateUserRequest model)
        {
            var user = getUser(id);

            // validate
            if (model.Email != user.Email && _context.Users.Any(x => x.Email == model.Email))
                throw new AppException("User with the email '" + model.Email + "' already exists");

            // hash password if it was entered
            if (!string.IsNullOrEmpty(model.Password))
                user.PasswordHash = BC.HashPassword(model.Password);

            // copy model to user and save
            _mapper.Map(model, user);
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var user = getUser(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        // helper methods

        private User getUser(Guid id)
        {
            var user = _context.Users.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
    }
}
