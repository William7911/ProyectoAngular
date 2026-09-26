using API_REST_PO.Models;
using Microsoft.EntityFrameworkCore;

namespace API_REST_PO.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Esto creará una tabla llamada "Productos" en SQL Server
        public DbSet<Producto> Productos { get; set; }
    }
}