using ControleDeEstoque.API.Domain.Entities;

namespace ControleDeEstoque.API.Services.Interfaces
{
    public interface IItemPedidoService
    {
        Task<List<ItemPedido>> GetItemsPedidoAsync();
        Task<ItemPedido> GetItemsPedidoByIdAsync(int id);
        Task AddItemPedidoAsync(ItemPedido itemPedido);
        Task UpdateItemPedidoAsync(ItemPedido itemPedido);
        Task DeleteItemPedidoAsync(int id);
    }
}
