using ControleDeEstoque.API.Domain.Entities;
using ControleDeEstoque.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoque.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientesAsync()
        {
            var clientes = await _clienteService.GetClientesAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetClienteByIdAsync(int id)
        {
            var cliente = await _clienteService.GetClienteByIdAsync(id);
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> AddClienteAsync(Cliente cliente)
        {
            await _clienteService.AddClienteAsync(cliente);
            return CreatedAtAction(nameof(GetClienteByIdAsync), new { id = cliente.ClienteID }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClienteAsync(int id, Cliente cliente)
        {
            if (id != cliente.ClienteID) return BadRequest();
            await _clienteService.UpdateClienteAsync(cliente);
            return Ok(new { message = "Cliente updated" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClienteAsync(int id)
        {
            await _clienteService.DeleteClienteAsync(id);
            return Ok(new { message = "Cliente deleted" });
        }
    }
}
