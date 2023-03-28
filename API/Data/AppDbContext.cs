using bancodigital_api.Models;
using Microsoft.EntityFrameworkCore;

namespace bancodigital_api.Data
{
   public class AppDbContext : DbContext
    {
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
