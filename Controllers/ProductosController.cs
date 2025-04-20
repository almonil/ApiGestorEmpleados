using Microsoft.AspNetCore.Mvc;
using ApiGestorEmpleados.Data;
using ApiGestorEmpleados.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiGestorProductos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            return await _context.Productos.Include(p => p.Imagenes).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _context.Productos.Include(p => p.Imagenes)
                                                   .FirstOrDefaultAsync(p => p.Id == id);

            if (producto == null)
                return NotFound();

            return producto;
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            producto.FechaCreacion = DateTime.Now;
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Producto producto)
        {
            if (id != producto.Id)
                return BadRequest();

            _context.Entry(producto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
                return NotFound();

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("ordenados/precio")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductosOrdenadosPorPrecio()
        {
            return await _context.Productos
                                 .OrderBy(p => p.Precio)
                                 .ToListAsync();
        }
    }
}
