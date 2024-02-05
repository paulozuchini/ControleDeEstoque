using ControleDeEstoque.API.Context;
using ControleDeEstoque.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.API.Services.Interfaces
{
    public class ItemPedidoService : IItemPedidoService
    {
        private DatabaseContext _context;

        public ItemPedidoService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<ItemPedido>> GetItemsPedidoAsync()
        {
            return await _context.ItemPedido.ToListAsync();
        }

        public async Task<ItemPedido> GetItemsPedidoByIdAsync(int id)
        {
            var itemPedido = await _context.ItemPedido.FindAsync(id);
            if(itemPedido == null) throw new KeyNotFoundException("ItemPedido not found");
            return itemPedido;
        }

        public async Task AddItemPedidoAsync(ItemPedido itemPedido)
        {
            _context.ItemPedido.Add(itemPedido);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateItemPedidoAsync(ItemPedido itemPedido)
        {
            _context.Update(itemPedido);
            await UpdateItemPedidoAsync(itemPedido);
        }

        public async Task DeleteItemPedidoAsync(int id)
        {
            await _context.ItemPedido.Where(p => p.ItemPedidoID == id).ExecuteDeleteAsync();
        }
    }
}
