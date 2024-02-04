using ControleDeEstoque.API.Domain.Entities;
using ControleDeEstoque.API.Domain.Models;

namespace ControleDeEstoque.API.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetById(Guid id);
        void Create(CreateUserRequest model);
        void Update(Guid id, UpdateUserRequest model);
        void Delete(Guid id);
    }
}
