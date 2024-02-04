using ControleDeEstoque.API.Domain.Entities;
using ControleDeEstoque.API.Domain.Models;

namespace ControleDeEstoque.API.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(Guid id);
        Task AddUserAsync(CreateUserRequest model);
        Task UpdateUserAsync(Guid id, UpdateUserRequest model);
        Task DeleteUserAsync(Guid id);
    }
}
