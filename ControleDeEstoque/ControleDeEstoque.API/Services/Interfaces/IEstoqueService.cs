using ControleDeEstoque.API.Domain.Entities;

namespace ControleDeEstoque.API.Services.Interfaces
{
    public interface IEstoqueService
    {
        Task<List<Estoque>> GetItemsEstoqueAsync();
        Task<Estoque> GetItemEstoqueByIdAsync(int id);
        Task AddItemEstoqueAsync(Estoque itemEstoque);
        Task UpdateItemEstoqueAsync(Estoque itemEstoque);
        Task DeleteItemEstoqueAsync(int id);
    }
}
