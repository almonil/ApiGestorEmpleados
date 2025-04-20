namespace ApiGestorEmpleados.DTOs
{
    public class ProductoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }
    }
}