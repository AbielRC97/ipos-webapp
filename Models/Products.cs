using System.ComponentModel.DataAnnotations;
namespace ipos.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = string.Empty;
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0")]
        public decimal Precio { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "El precio debe ser mayor que 0")]
        public int Stock { get; set; }
    }
}
