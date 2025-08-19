using KamaCake.Application.Interfaces.Repository;
using KamaCake.Domain.Common;
using KamaCake.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace KamaCake.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepositoryAsync<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext context;

        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }
            
        public async Task<T> DeleteAsync(Guid id)
        {
            var findItem= await context.Set<T>().FindAsync(id);
            if (findItem == null)
                return null;

            context.Set<T>().Remove(findItem);
            await context.SaveChangesAsync();
            return findItem;
        }

        public async Task<List<T>> GetAllAsync()
        {
           return await context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            var findItem = await context.Set<T>().FindAsync(id);
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
           var findItem= await context.Set<T>().FindAsync(entity.Id);
            if (findItem == null) throw new Exception("Not found"); ;
            context.Entry(findItem).CurrentValues.SetValues(entity);
            await context.SaveChangesAsync();
            return findItem;
        }
    }
}
