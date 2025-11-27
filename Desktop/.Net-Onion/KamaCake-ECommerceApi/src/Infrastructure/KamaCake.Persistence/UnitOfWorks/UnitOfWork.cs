using KamaCake.Application.Interfaces.Repositories;
using KamaCake.Application.Interfaces.UnitOfWorks;
using KamaCake.Persistence.Context;
using KamaCake.Persistence.Repositories;

namespace KamaCake.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        //private readonly AppContext context;
        private readonly ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async ValueTask DisposeAsync() => await context.DisposeAsync();
        public int Save() => context.SaveChanges();
        public async Task<int> SaveAsync() => await context.SaveChangesAsync();
        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(context);
        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(context);
       
    }
}
