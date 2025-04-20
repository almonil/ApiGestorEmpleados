using ApiGestorEmpleados.Data;
using ApiGestorEmpleados.Services;
using ApiGestorEmpleados.Services.ApiGestorProductos.Services;
using ApiGestorEmpleados.Services.Interfaces;
using ApiGestorEmpleados.Services.Interfaces.ApiGestorProductos.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar la cadena de conexión
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Registrar los servicios
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IImagenProductoService, ImagenProductoService>();

// 3. Servicios de ASP.NET Core
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 4. Configuración del pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Habilitar el acceso a archivos estáticos en wwwroot (incluyendo imágenes)
app.UseStaticFiles(); // Esto servirá los archivos estáticos en wwwroot

// Si deseas especificar una carpeta para las imágenes:
app.UseStaticFiles(new Microsoft.AspNetCore.Builder.StaticFileOptions
{
    FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagenes")),
    RequestPath = "/imagenes" // Esto hace que las imágenes estén accesibles bajo la ruta /imagenes
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
