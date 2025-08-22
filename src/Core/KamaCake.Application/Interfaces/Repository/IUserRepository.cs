using KamaCake.Domain.Entities;

namespace KamaCake.Application.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task CreateAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<bool> DeleteAsync(Guid id);
        Task<User?> GetByIdAsync(Guid id);
        Task<User?> GetByNameAsync(string userName);
        Task<User?> GetByEmailAsync(string email);
        Task<List<User>> GetAllAsync();
    }
}
