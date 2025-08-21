using KamaCake.Application.Interfaces.Repository;
using KamaCake.Domain.Entities;
using KamaCake.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace KamaCake.Persistence.Repositories
{
    public class CakeRepository:GenericRepository<Cake>,ICakeRepository
    {
        private readonly ApplicationDbContext context;

        public CakeRepository(ApplicationDbContext context):base(context) 
        {
            this.context = context;
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await context.Cakes.AnyAsync(c => c.Name.ToLower() == name.ToLower());
        }

       
    }
}
