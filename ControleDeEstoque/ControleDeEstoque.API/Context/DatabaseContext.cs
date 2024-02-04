using ControleDeEstoque.API.Domain.Entities;
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

        public DbSet<User> Users { get; set; }
    }
}
