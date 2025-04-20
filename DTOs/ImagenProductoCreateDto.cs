namespace ApiGestorEmpleados.DTOs
{
    public class ImagenProductoCreateDto
    {
        public IFormFile Imagen { get; set; }
        public int ProductoId { get; set; }
    }
}
