using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ipos.Models;
using ipos.Repositories;
using ipos.Services;

namespace ipos.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IService<Product> _service;

    [BindProperty]
    public decimal TotalInventario { get; set; }
    [BindProperty]
    public bool MostrarTotal { get; set; }

    public IndexModel(IService<Product> service, ILogger<IndexModel> logger)
    {
        _service = service;
        _logger = logger;
    }

    public List<Product> Productos { get; set; } = new();

    public async Task OnGetAsync()
    {
        _logger.LogInformation("Obteniendo todos los productos");
        Productos = await _service.GetAllAsync();
    }

    // Método POST genérico
    public async Task<IActionResult> OnPostAsync()
    {
        Productos = await _service.GetAllAsync();

        if (MostrarTotal)
        {
            TotalInventario = Productos.Sum(p => p.Precio * p.Stock);
        }

        return Page(); // Mantener la misma página
    }
}
