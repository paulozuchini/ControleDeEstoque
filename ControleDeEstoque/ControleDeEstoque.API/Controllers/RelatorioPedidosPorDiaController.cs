using ControleDeEstoque.API.Domain.Models;
using ControleDeEstoque.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioPedidosPorDiaController : ControllerBase
    {
        private readonly IRelatorioPedidosPorDiaService _relatorioPedidosPorDiaService;

        public RelatorioPedidosPorDiaController(IRelatorioPedidosPorDiaService relatorioPedidosPorDiaService)
        {
            _relatorioPedidosPorDiaService = relatorioPedidosPorDiaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RelatorioPedidosPorDiaModel>>> GetRelatorioPedidosPorDia([FromQuery] DateTime dataInicial, [FromQuery] DateTime dataFinal)
        {
            try
            {
                var relatorio = await _relatorioPedidosPorDiaService.GetRelatorioPedidosPorDiaAsync(dataInicial, dataFinal);
                return Ok(relatorio);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar o relatório: {ex.Message}");
            }
        }
    }
}
