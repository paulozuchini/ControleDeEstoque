using ControleDeEstoque.API.Domain.Entities;

namespace ControleDeEstoque.API.Services.Interfaces
{
    public interface IPedidoService
    {
        Task<List<Pedido>> GetPedidosAsync();
        Task<Pedido> GetPedidoByIdAsync(int id);
        Task AddPedidoAsync(Pedido pedido);
        Task UpdatePedidoAsync(Pedido pedido);
        Task DeletePedidoAsync(int id);
    }
}
