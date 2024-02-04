using ControleDeEstoque.API.Domain.Entities;

namespace ControleDeEstoque.API.Services.Interfaces
{
    public interface IFaturamentoService
    {
        Task<List<Faturamento>> GetFaturamentosAsync();
        Task<Faturamento> GetFaturamentoByIdAsync(int id);
        Task AddFaturamentoAsync(Faturamento faturamento);
        Task UpdateFaturamentoAsync(Faturamento faturamento);
        Task DeleteFaturamentoAsync(int id);
    }
}
