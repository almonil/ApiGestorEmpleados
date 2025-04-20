namespace ApiGestorEmpleados.Controllers
{
    using global::ApiGestorEmpleados.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;
    using System;
    using System.IO;

    [ApiController]
    [Route("api/[controller]")]
    public class ImagenesProductoController : ControllerBase
    {
        private readonly IImagenProductoService _service;

        public ImagenesProductoController(IImagenProductoService service)
        {
            _service = service;
        }

        // POST: api/imagenesproducto
        [HttpPost]
        public async Task<IActionResult> SubirImagen([FromForm] IFormFile imagen, [FromForm] int productoId)
        {
            if (imagen == null || productoId == 0)
                return BadRequest("Se requiere una imagen y un productoId válido.");

            // Validar tipo de archivo (solo imágenes)
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var extension = Path.GetExtension(imagen.FileName).ToLower();

            if (Array.IndexOf(allowedExtensions, extension) < 0)
            {
                return BadRequest("El archivo no es una imagen válida.");
            }

            try
            {
                var imagenGuardada = await _service.CrearImagenAsync(imagen, productoId);

                // Devolver la URL de la imagen guardada (por ejemplo, si se guarda en una carpeta pública)
                var urlImagen = $"{Request.Scheme}://{Request.Host}/imagenes/{imagenGuardada.Id}";

                return Ok(new { url = urlImagen });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al subir la imagen: " + ex.Message);
            }
        }

        // GET: api/imagenesproducto
        [HttpGet]
        public async Task<IActionResult> ObtenerTodas()
        {
            var imagenes = await _service.ObtenerTodasAsync();
            return Ok(imagenes);
        }

        // GET: api/imagenesproducto/5
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var imagen = await _service.ObtenerPorIdAsync(id);
            if (imagen == null)
                return NotFound();

            // Aquí puedes devolver la URL de la imagen si es necesario
            var urlImagen = $"{Request.Scheme}://{Request.Host}/imagenes/{imagen.Id}";

            return Ok(new { url = urlImagen });
        }

        // DELETE: api/imagenesproducto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var eliminado = await _service.EliminarAsync(id);
            if (!eliminado)
                return NotFound();

            return NoContent();
        }
    }
}
