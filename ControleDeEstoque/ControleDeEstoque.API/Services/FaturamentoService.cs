using ControleDeEstoque.API.Context;
using ControleDeEstoque.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.API.Services.Interfaces
{
    public class FaturamentoService : IFaturamentoService
    {
        private DatabaseContext _context;

        public FaturamentoService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Faturamento>> GetFaturamentosAsync()
        {
            return await _context.Faturamento.ToListAsync();
        }


        public async Task<Faturamento> GetFaturamentoByIdAsync(int id)
        {
            var faturamento = await _context.Faturamento.FindAsync(id);
            if(faturamento == null) throw new KeyNotFoundException("Faturamento not found");
            return faturamento;
        }

        public async Task AddFaturamentoAsync(Faturamento faturamento)
        {
            _context.Faturamento.Add(faturamento);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFaturamentoAsync(Faturamento faturamento)
        {
            _context.Update(faturamento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFaturamentoAsync(int id)
        {
            await _context.Faturamento.Where(f => f.FaturamentoID == id).ExecuteDeleteAsync();
        }
    }
}
