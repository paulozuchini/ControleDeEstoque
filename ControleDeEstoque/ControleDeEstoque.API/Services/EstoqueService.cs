using ControleDeEstoque.API.Context;
using ControleDeEstoque.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.API.Services.Interfaces
{
    public class EstoqueService : IEstoqueService
    {
        private DatabaseContext _context;

        public EstoqueService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Estoque>> GetItemsEstoqueAsync()
        {
            return await _context.Estoque.ToListAsync();
        }

        public async Task<Estoque> GetItemEstoqueByIdAsync(int id)
        {
            var item = await _context.Estoque.FindAsync(id);
            if (item == null) throw new KeyNotFoundException("ItemEstoque not found");
            return item;
        }

        public async Task AddItemEstoqueAsync(Estoque itemEstoque)
        {
            _context.Estoque.Add(itemEstoque);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateItemEstoqueAsync(Estoque itemEstoque)
        {
            _context.Update(itemEstoque);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemEstoqueAsync(int id)
        {
            await _context.Estoque.Where(i => i.ItemID == id).ExecuteDeleteAsync();
        }
    }
}
