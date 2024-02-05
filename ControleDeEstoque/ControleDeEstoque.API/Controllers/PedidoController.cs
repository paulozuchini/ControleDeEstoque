using ControleDeEstoque.API.Domain.Entities;
using ControleDeEstoque.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleDePedido.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidosAsync()
        {
            var pedidos = await _pedidoService.GetPedidosAsync();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedidoByIdAsync(int id)
        {
            var pedido = await _pedidoService.GetPedidoByIdAsync(id);
            return Ok(pedido);
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> AddPedidoAsync(Pedido pedido)
        {
            await _pedidoService.AddPedidoAsync(pedido);
            return CreatedAtAction(nameof(GetPedidoByIdAsync), new { id = pedido.PedidoID }, pedido);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItemPedidoAsync(int id, Pedido pedido)
        {
            if (id != pedido.PedidoID) return BadRequest();
            await _pedidoService.UpdatePedidoAsync(pedido);
            return Ok(new { message = "Pedido updated" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemPedidoAsync(int id)
        {
            await _pedidoService.DeletePedidoAsync(id);
            return Ok(new { message = "Pedido deleted" });
        }
    }
}
