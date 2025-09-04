using KamaCake.Application.Interfaces.Repository;
using KamaCake.Domain.Entities;
using KamaCake.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace KamaCake.Persistence.Repositories
{
    public class CartRepository:GenericRepository<Cart>,ICartRepository
    {
        private readonly ApplicationDbContext context;

        public CartRepository(ApplicationDbContext context):base(context) 
        {
            this.context = context;
        }

        public async Task<Cart?> GetByUserIdAsync(Guid userId)
        {
            return await context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);
        }
    }
}
