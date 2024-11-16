using Microsoft.EntityFrameworkCore;
using ServicoFornecedor.Models;

namespace ServicoFornecedor.Repositorio.Infra
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Fornecedor> fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fornecedor>().HasKey(p=> p.IdFornecedor);
            base.OnModelCreating(modelBuilder);
        }
    }
}
