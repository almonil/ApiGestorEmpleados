namespace ApiGestorEmpleados.Services
{
    using ApiGestorEmpleados.DTOs;
    using ApiGestorEmpleados.Models;
    using ApiGestorEmpleados.Services.Interfaces.ApiGestorProductos.Services.Interfaces;
    using ApiGestorEmpleados.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using ApiGestorEmpleados.Data;

    namespace ApiGestorProductos.Services
    {
        public class ProductoService : IProductoService
        {
            private readonly AppDbContext _context;

            public ProductoService(AppDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<ProductoDto>> ObtenerTodos()
            {
                var productos = await _context.Productos.ToListAsync();
                return productos.Select(p => new ProductoDto
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    Precio = p.Precio,
                    FechaCreacion = p.FechaCreacion,
                    Estado = p.Estado
                });
            }

            public async Task<ProductoDto> ObtenerPorId(int id)
            {
                var p = await _context.Productos.FindAsync(id);
                if (p == null) return null;

                return new ProductoDto
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    Precio = p.Precio,
                    FechaCreacion = p.FechaCreacion,
                    Estado = p.Estado
                };
            }

            public async Task<ProductoDto> Crear(CrearProductoDto dto)
            {
                var producto = new Producto
                {
                    Nombre = dto.Nombre,
                    Descripcion = dto.Descripcion,
                    Precio = dto.Precio,
                    FechaCreacion = DateTime.Now,
                    Estado = dto.Estado
                };

                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();

                return new ProductoDto
                {
                    Id = producto.Id,
                    Nombre = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    Precio = producto.Precio,
                    FechaCreacion = producto.FechaCreacion,
                    Estado = producto.Estado
                };
            }

            public async Task<bool> Actualizar(int id, CrearProductoDto dto)
            {
                var producto = await _context.Productos.FindAsync(id);
                if (producto == null) return false;

                producto.Nombre = dto.Nombre;
                producto.Descripcion = dto.Descripcion;
                producto.Precio = dto.Precio;
                producto.Estado = dto.Estado;

                await _context.SaveChangesAsync();
                return true;
            }

            public async Task<bool> Eliminar(int id)
            {
                var producto = await _context.Productos.FindAsync(id);
                if (producto == null) return false;

                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}