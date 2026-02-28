using KamaCake.Domain.Entities;

namespace KamaCake.Application.Interfaces.Repository
{
    public interface ICakeRepository:IGenericRepositoryAsync<Cake>
    {
        Task<bool> ExistsByNameAsync(string name);
    }
}
