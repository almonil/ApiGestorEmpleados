namespace ApiGestorEmpleados.Services.Interfaces
{
    using ApiGestorEmpleados.DTOs;
    
    namespace ApiGestorProductos.Services.Interfaces
    {
        public interface IProductoService
        {
            Task<IEnumerable<ProductoDto>> ObtenerTodos();
            Task<ProductoDto> ObtenerPorId(int id);
            Task<ProductoDto> Crear(CrearProductoDto nuevoProducto);
            Task<bool> Actualizar(int id, CrearProductoDto productoActualizado);
            Task<bool> Eliminar(int id);
        }
    }
}

