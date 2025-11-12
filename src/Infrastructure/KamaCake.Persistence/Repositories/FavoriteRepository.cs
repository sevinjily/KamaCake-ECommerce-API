using KamaCake.Application.Interfaces.Repository;
using KamaCake.Domain.Entities;
using KamaCake.Persistence.Context;

namespace KamaCake.Persistence.Repositories
{
    public class FavoriteRepository : GenericRepository<Favorite>, IFavoriteRepository
    {
        public FavoriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
