using ApiGestorEmpleados.Models;

public class ImagenProducto
{
    public int Id { get; set; }

    public string NombreArchivo { get; set; }

    public string Url { get; set; }

    public int ProductoId { get; set; }

    public Producto Producto { get; set; }
}
