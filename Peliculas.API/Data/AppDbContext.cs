using Microsoft.EntityFrameworkCore;
using Peliculas.API.Models;

namespace Peliculas.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().ToTable("Categoria");
            base.OnModelCreating(modelBuilder); 
        }
    }
}
