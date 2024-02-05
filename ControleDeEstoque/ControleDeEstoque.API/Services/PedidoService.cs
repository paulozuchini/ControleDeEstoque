using ControleDeEstoque.API.Context;
using ControleDeEstoque.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.API.Services.Interfaces
{
    public class PedidoService : IPedidoService
    {
        private DatabaseContext _context;

        public PedidoService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Pedido>> GetPedidosAsync()
        {
            return await _context.Pedido.ToListAsync();
        }

        public async Task<Pedido> GetPedidoByIdAsync(int id)
        {
            var pedido = await _context.Pedido.FindAsync(id);
            if(pedido == null) throw new KeyNotFoundException("Pedido not found");
            return pedido;
        }

        public async Task AddPedidoAsync(Pedido pedido)
        {
            _context.Pedido.Add(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePedidoAsync(Pedido pedido)
        {
            _context.Update(pedido);
            await UpdatePedidoAsync(pedido);
        }

        public async Task DeletePedidoAsync(int id)
        {
            await _context.Pedido.Where(p => p.PedidoID == id).ExecuteDeleteAsync();
        }
    }
}
