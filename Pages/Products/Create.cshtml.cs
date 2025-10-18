using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ipos.Models;
using ipos.Services;

namespace ipos.Pages.Productos
{
    public class CreateModel : PageModel
    {
        private readonly IService<Product> _service;

        public CreateModel(IService<Product> service)
        {
            _service = service;
        }

        [BindProperty]
        public Product NuevoProducto { get; set; } = new();

        public void OnGet()
        {
            // Se ejecuta al abrir la página. No necesitamos cargar datos.
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _service.AddAsync(NuevoProducto);

            // Redirige a la página de listado
            return RedirectToPage("/Index");
        }
    }
}
