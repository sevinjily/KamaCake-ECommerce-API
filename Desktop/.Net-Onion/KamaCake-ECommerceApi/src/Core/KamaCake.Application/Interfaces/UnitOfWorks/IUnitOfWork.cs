using KamaCake.Application.Interfaces.Repositories;
using KamaCake.Domain.Common;

namespace KamaCake.Application.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        IReadRepository<T> GetReadRepository<T>() where T : class,IEntityBase,new();
        IWriteRepository<T> GetWriteRepository<T>() where T : class, IEntityBase, new();
        Task<int> SaveAsync(); //asinxron olacaqsa Task ile yaziriq
        int Save();//asinxron olmayan prosesler ucun yaziriq.asinxron olmadigi ucun Task yazmiriq


    }
}
