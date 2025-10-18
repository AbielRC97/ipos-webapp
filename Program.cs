using Microsoft.EntityFrameworkCore;
using ipos.Data;
using ipos.Models;
using ipos.Repositories;
using ipos.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// 🔧 Leer puerto de entorno o usar 8080 como fallback
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(int.Parse(port));
});

// Agregar servicio de DbContext con SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositorio y servicio genérico
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));

builder.Services.AddRazorPages();

var app = builder.Build();

// Configurar cultura global
var culture = new CultureInfo("es-MX");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

// Crear datos en productos si no existen
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();

    if (!db.Productos.Any())
    {
        db.Productos.AddRange(
            new Product { Nombre = "Taza", Precio = 50, Stock = 10 },
            new Product { Nombre = "Plato", Precio = 80, Stock = 5 }
        );
        db.SaveChanges();
    }
}

// Middleware y pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// ❌ Se Elimina esta línea si estás en Coolify (ya maneja HTTPS con Traefik)
// app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages().WithStaticAssets();

app.Run();
