using Microsoft.EntityFrameworkCore;
using ipos.Models;

namespace ipos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Productos { get; set; }
    }
}
