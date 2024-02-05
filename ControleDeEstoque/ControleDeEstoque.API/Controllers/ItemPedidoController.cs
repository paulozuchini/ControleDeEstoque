using ControleDeEstoque.API.Domain.Entities;
using ControleDeEstoque.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleDePedido.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemPedidoController : ControllerBase
    {
        private readonly IItemPedidoService _itemPedidoService;

        public ItemPedidoController(IItemPedidoService itemPedidoService)
        {
            _itemPedidoService = itemPedidoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemPedido>>> GetItemsPedidoAsync()
        {
            var itemItemPedido = await _itemPedidoService.GetItemsPedidoAsync();
            return Ok(itemItemPedido);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemPedido>> GetItemsPedidoByIdAsync(int id)
        {
            var pedido = await _itemPedidoService.GetItemsPedidoByIdAsync(id);
            return Ok(pedido);
        }

        [HttpPost]
        public async Task<ActionResult<ItemPedido>> AddItemPedidoAsync(ItemPedido pedido)
        {
            await _itemPedidoService.AddItemPedidoAsync(pedido);
            return CreatedAtAction(nameof(GetItemsPedidoByIdAsync), new { id = pedido.ItemPedidoID }, pedido);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItemItemPedidoAsync(int id, ItemPedido pedido)
        {
            if (id != pedido.ItemPedidoID) return BadRequest();
            await _itemPedidoService.UpdateItemPedidoAsync(pedido);
            return Ok(new { message = "ItemPedido updated" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemItemPedidoAsync(int id)
        {
            await _itemPedidoService.DeleteItemPedidoAsync(id);
            return Ok(new { message = "ItemPedido deleted" });
        }
    }
}
