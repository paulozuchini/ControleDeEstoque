using ControleDeEstoque.API.Domain.Entities;
using ControleDeEstoque.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeFaturamento.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FaturamentoController : ControllerBase
    {
        private readonly IFaturamentoService _faturamentoService;

        public FaturamentoController(IFaturamentoService faturamentoService)
        {
            _faturamentoService = faturamentoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Faturamento>>> GetFaturamentosAsync()
        {
            var faturamento = await _faturamentoService.GetFaturamentosAsync();
            return Ok(faturamento);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Faturamento>> GetFaturamentoByIdAsync(int id)
        {
            var faturamento = await _faturamentoService.GetFaturamentoByIdAsync(id);
            return Ok(faturamento);
        }

        [HttpPost]
        public async Task<ActionResult<Faturamento>> AddFaturamentoAsync(Faturamento faturamento)
        {
            await _faturamentoService.AddFaturamentoAsync(faturamento);
            return CreatedAtAction(nameof(GetFaturamentoByIdAsync), new { id = faturamento.FaturamentoID }, faturamento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItemFaturamentoAsync(int id, Faturamento faturamento)
        {
            if (id != faturamento.FaturamentoID) return BadRequest();
            await _faturamentoService.UpdateFaturamentoAsync(faturamento);
            return Ok(new { message = "Faturamento updated" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemFaturamentoAsync(int id)
        {
            await _faturamentoService.DeleteFaturamentoAsync(id);
            return Ok(new { message = "Faturamento deleted" });
        }
    }
}
