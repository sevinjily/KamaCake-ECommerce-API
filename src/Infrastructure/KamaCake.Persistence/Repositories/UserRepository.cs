using KamaCake.Application.Interfaces.Repository;
using KamaCake.Domain.Entities;
using KamaCake.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace KamaCake.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task CreateAsync(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var findItem = await context.Users.FindAsync(id);
            if (findItem == null) return false;

            context.Users.Remove(findItem);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
        return await context.Users.FirstOrDefaultAsync(x => x.Email == email);            
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await context.Users.FindAsync(id);
        }

        public async Task<User?> GetByNameAsync(string userName)
        {
            return await context.Users.FirstOrDefaultAsync(x=>x.UserName== userName);
        }

        public async Task<User> UpdateAsync(User user)
        {
            var existingUser = await context.Users.FindAsync(user.Id);
            if (existingUser == null) throw new Exception("User not found");

            // update specific fields
            existingUser.FullName = user.FullName;
            existingUser.Email = user.Email;
            existingUser.UserName = user.UserName;

            await context.SaveChangesAsync();
            return user;

        }

       
    }
}
