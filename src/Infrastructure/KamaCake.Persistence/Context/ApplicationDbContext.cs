using KamaCake.Domain.Common;
using KamaCake.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KamaCake.Persistence.Context
{
    public class ApplicationDbContext : IdentityDbContext<User,Role,Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Cake> Cakes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreateDate = DateTime.UtcNow;
                    entry.Entity.UpdateDate = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {

                    entry.Entity.UpdateDate = DateTime.UtcNow;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
