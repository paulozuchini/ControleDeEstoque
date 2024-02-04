using ControleDeEstoque.API.Context;
using ControleDeEstoque.API.Domain.Entities;
using ControleDeEstoque.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.API.Services
{
    public class ClienteService : IClienteService
    {
        private DatabaseContext _context;

        public ClienteService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> GetClientesAsync()
        {
            return await _context.Cliente.ToListAsync();
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null) throw new KeyNotFoundException("Cliente not found");
            return cliente;
        }

        public async Task AddClienteAsync(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClienteAsync(Cliente cliente)
        {
            _context.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClienteAsync(int id)
        {
            await _context.Cliente.Where(c => c.ClienteID == id).ExecuteDeleteAsync();
        }
    }
}
