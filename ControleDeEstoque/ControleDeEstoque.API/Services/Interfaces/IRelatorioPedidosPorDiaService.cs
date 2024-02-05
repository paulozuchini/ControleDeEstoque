using ControleDeEstoque.API.Domain.Models;

namespace ControleDeEstoque.API.Services.Interfaces
{
    public interface IRelatorioPedidosPorDiaService
    {
        Task<List<RelatorioPedidosPorDiaModel>> GetRelatorioPedidosPorDiaAsync(DateTime dataInicial, DateTime dataFinal);
    }
}