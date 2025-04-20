using ApiGestorEmpleados.Data;
using ApiGestorEmpleados.Models;
using ApiGestorEmpleados.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ApiGestorEmpleados.Services
{
    public class ImagenProductoService : IImagenProductoService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ImagenProductoService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<ImagenProducto> CrearImagenAsync(IFormFile imagen, int productoId)
        {
            if (imagen == null || imagen.Length == 0)
                throw new ArgumentException("La imagen es inválida.");

            var nombreArchivo = Guid.NewGuid().ToString() + Path.GetExtension(imagen.FileName);
            var rutaCarpeta = Path.Combine(_env.WebRootPath ?? "wwwroot", "imagenes");

            if (!Directory.Exists(rutaCarpeta))
                Directory.CreateDirectory(rutaCarpeta);

            var rutaArchivo = Path.Combine(rutaCarpeta, nombreArchivo);

            using (var stream = new FileStream(rutaArchivo, FileMode.Create))
            {
                await imagen.CopyToAsync(stream);
            }

            var url = $"imagenes/{nombreArchivo}";

            var imagenProducto = new ImagenProducto
            {
                NombreArchivo = nombreArchivo,
                Url = url,
                ProductoId = productoId
            };

            _context.ImagenesProducto.Add(imagenProducto);
            await _context.SaveChangesAsync();

            return imagenProducto;
        }

        public async Task<IEnumerable<ImagenProducto>> ObtenerTodasAsync()
        {
            return await _context.ImagenesProducto.ToListAsync();
        }

        public async Task<ImagenProducto> ObtenerPorIdAsync(int id)
        {
            return await _context.ImagenesProducto.FindAsync(id);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var imagen = await _context.ImagenesProducto.FindAsync(id);
            if (imagen == null)
                return false;

            var rutaArchivo = Path.Combine(_env.WebRootPath ?? "wwwroot", imagen.Url);
            if (File.Exists(rutaArchivo))
                File.Delete(rutaArchivo);

            _context.ImagenesProducto.Remove(imagen);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
