using KamaCake.Domain.Entities;

namespace KamaCake.Application.Interfaces.Repository
{
    public interface ICartRepository:IGenericRepositoryAsync<Cart>
    {
        Task<Cart?> GetByUserIdAsync(Guid userId);
    }
}
