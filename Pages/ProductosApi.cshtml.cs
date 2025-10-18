using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ipos.Models;
using ipos.Services;
using System.Threading.Tasks;

namespace ipos.Pages
{
    public class ProductosApiModel : PageModel
    {
        private readonly IService<Product> _service;

        public ProductosApiModel(IService<Product> service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var productos = await _service.GetAllAsync();
            
            // Retorna JSON automáticamente
            return new JsonResult(productos);
        }
    }
}
