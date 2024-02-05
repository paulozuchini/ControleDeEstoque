using ControleDeEstoque.API.Domain.Entities;
using ControleDeEstoque.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoque.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueService _estoqueService;

        public EstoqueController(IEstoqueService estoqueService)
        {
            _estoqueService = estoqueService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estoque>>> GetItemsEstoqueAsync()
        {
            var itemEstoques = await _estoqueService.GetItemsEstoqueAsync();
            return Ok(itemEstoques);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Estoque>> GetItemEstoqueByIdAsync(int id)
        {
            var itemEstoque = await _estoqueService.GetItemEstoqueByIdAsync(id);
            return Ok(itemEstoque);
        }

        [HttpPost]
        public async Task<ActionResult<Estoque>> AddItemEstoqueAsync(Estoque itemEstoque)
        {
            await _estoqueService.AddItemEstoqueAsync(itemEstoque);
            return CreatedAtAction(nameof(GetItemEstoqueByIdAsync), new { id = itemEstoque.ItemID }, itemEstoque);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItemEstoqueAsync(int id, Estoque itemEstoque)
        {
            if (id != itemEstoque.ItemID) return BadRequest();
            await _estoqueService.UpdateItemEstoqueAsync(itemEstoque);
            return Ok(new { message = "ItemEstoque updated" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemEstoqueAsync(int id)
        {
            await _estoqueService.DeleteItemEstoqueAsync(id);
            return Ok(new { message = "ItemEstoque deleted" });
        }
    }
}
