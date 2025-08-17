using KamaCake.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KamaCake.Persistence.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }

        public DbSet<Cake> Cakes { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
