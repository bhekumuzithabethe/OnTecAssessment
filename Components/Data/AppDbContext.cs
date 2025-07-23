using Microsoft.EntityFrameworkCore;
using OnTecAssessment.Components.Domain;

namespace OnTecAssessment.Components.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
    }
}
