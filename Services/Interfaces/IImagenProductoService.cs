using ApiGestorEmpleados.Models;

namespace ApiGestorEmpleados.Services.Interfaces
{
    public interface IImagenProductoService
    {
        Task<ImagenProducto> CrearImagenAsync(IFormFile imagen, int productoId);
        Task<IEnumerable<ImagenProducto>> ObtenerTodasAsync();
        Task<ImagenProducto> ObtenerPorIdAsync(int id);
        Task<bool> EliminarAsync(int id);
    }
}
