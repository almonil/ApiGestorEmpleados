namespace ApiGestorEmpleados.DTOs
{
    public class ImagenProductoDto
    {
        public int Id { get; set; }
        public string NombreArchivo { get; set; }
        public string Url { get; set; }
        public int ProductoId { get; set; }
    }
}
