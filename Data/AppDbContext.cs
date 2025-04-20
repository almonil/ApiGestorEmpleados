using Microsoft.EntityFrameworkCore;
using ApiGestorEmpleados.Models;

namespace ApiGestorEmpleados.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<ImagenProducto> ImagenesProducto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar la relación entre Producto e ImagenProducto
            modelBuilder.Entity<Producto>()
                .HasMany(p => p.Imagenes)
                .WithOne(i => i.Producto)
                .HasForeignKey(i => i.ProductoId);

            // Configuración del tipo de columna para Precio (decimal)
            modelBuilder.Entity<Producto>()
                .Property(p => p.Precio)
                .HasColumnType("decimal(18,2)"); // Esto asegura que el precio tiene dos decimales
        }
    }
}
