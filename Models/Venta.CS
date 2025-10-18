using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ipos.Models
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }

        // FK a Producto
        [Required]
        public int ProductoId { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        [Column(TypeName = "DATE")] // EF Core usará tipo DATE en SQLite
        public DateTime Fecha { get; set; }

        // Relación opcional con Producto
        // public Product Producto { get; set; }
    }
}
