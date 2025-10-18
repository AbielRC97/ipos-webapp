using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ipos.Models;

namespace ipos.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public List<Product> Productos { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        Productos = new List<Product>();
    }

    public void OnGet()
    {
        Productos = new List<Product>
            {
                new Product { Id = 1, Nombre = "Taza", Precio = 50, Stock = 10 },
                new Product { Id = 2, Nombre = "Plato", Precio = 80, Stock = 5 }
            };
    }
}
