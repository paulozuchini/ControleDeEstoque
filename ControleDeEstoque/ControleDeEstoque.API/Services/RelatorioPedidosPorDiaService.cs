using ControleDeEstoque.API.Context;
using ControleDeEstoque.API.Domain.Models;
using ControleDeEstoque.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.API.Services
{
    public class RelatorioPedidosPorDiaService : IRelatorioPedidosPorDiaService
    {
        private readonly DatabaseContext _context;

        public RelatorioPedidosPorDiaService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<RelatorioPedidosPorDiaModel>> GetRelatorioPedidosPorDiaAsync(DateTime dataInicial, DateTime dataFinal)
        {
            return await _context.RelatorioPedidosPorDia
                .Where(p => p.DataPedido >= dataInicial && p.DataPedido <= dataFinal)
                .Select(p => new RelatorioPedidosPorDiaModel
                {
                    DataPedido = p.DataPedido,
                    ClienteID = p.ClienteID,
                    NomeCliente = p.NomeCliente,
                    PedidoID = p.PedidoID,
                    StatusPedido = p.StatusPedido,
                    ItemID = p.ItemID,
                    NomeProduto = p.NomeProduto,
                    Quantidade = p.Quantidade
                })
                .ToListAsync();
        }
    }
}
