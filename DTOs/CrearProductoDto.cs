namespace ApiGestorEmpleados.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public class CrearProductoDto
    {
        [Required]
        [StringLength(100)]
        public required string Nombre { get; set; }

        [StringLength(255)]
        public required string Descripcion { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal Precio { get; set; }

        public bool Estado { get; set; }
    }
}
