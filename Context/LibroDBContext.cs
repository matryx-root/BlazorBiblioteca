using Microsoft.EntityFrameworkCore;
using BlazorBiblioteca.Shared;

namespace BlazorBiblioteca.Context // 👈 Namespace correcto
{
    public class LibroDBContext : DbContext
    {
        public LibroDBContext(DbContextOptions<LibroDBContext> options) : base(options) { }

        public DbSet<Libro> Libros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libro>().ToTable("Libros"); // Asegura que la tabla se llama "Libros"
        }
    }
}
