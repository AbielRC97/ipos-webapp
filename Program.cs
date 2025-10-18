using Microsoft.EntityFrameworkCore;
using ipos.Data;
using ipos.Models;
using ipos.Repositories;
using ipos.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicio de DbContext con SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
// Repositorio y servicio genérico
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configurar cultura global
var culture = new CultureInfo("es-MX");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

//Creamos datos en productos
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


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
