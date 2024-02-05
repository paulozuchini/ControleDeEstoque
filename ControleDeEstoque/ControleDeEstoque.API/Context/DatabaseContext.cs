using ControleDeEstoque.API.Domain.Entities;
using ControleDeEstoque.API.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ControleDeEstoque.API.Context
{
    public class DatabaseContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private IDbConnection conn { get; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options, 
            IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
            conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(conn.ToString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapear a view RelatorioPedidosPorDia no contexto
            modelBuilder.Entity<RelatorioPedidosPorDiaModel>(entity =>
            {
                entity.HasNoKey(); // Indicar que a classe não tem uma chave primária definida
                entity.ToView("RelatorioPedidosPorDia"); // Nome da view no banco de dados
            });
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<Faturamento> Faturamento { get; set; }
        public DbSet<ItemPedido> ItemPedido { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RelatorioPedidosPorDiaModel> RelatorioPedidosPorDia { get; set; }
    }
}
