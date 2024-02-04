using ControleDeEstoque.API.Domain.Entities;

namespace ControleDeEstoque.API.Services.Interfaces
{
    public interface IItemEstoqueService
    {
        Task<List<ItemEstoque>> GetItemEstoquesAsync();
        Task<ItemEstoque> GetItemEstoqueByIdAsync(int id);
        Task AddItemEstoqueAsync(ItemEstoque itemEstoque);
        Task UpdateItemEstoqueAsync(ItemEstoque itemEstoque);
        Task DeleteItemEstoqueAsync(int id);
    }
}
