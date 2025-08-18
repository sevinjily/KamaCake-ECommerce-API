using KamaCake.Application.Interfaces.Repository;
using KamaCake.Domain.Entities;
using KamaCake.Persistence.Context;

namespace KamaCake.Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context) { }

    }
}
