using ControleDeEstoque.API.Domain.Entities;

namespace ControleDeEstoque.API.Services.Interfaces
{
    public interface IItemPedidoService
    {
        Task<List<ItemPedido>> GetItemPedidosAsync();
        Task<ItemPedido> GetItemPedidoByIdAsync(int id);
        Task AddItemPedidoAsync(ItemPedido itemPedido);
        Task UpdateItemPedidoAsync(ItemPedido itemPedido);
        Task DeleteItemPedidoAsync(int id);
    }
}
