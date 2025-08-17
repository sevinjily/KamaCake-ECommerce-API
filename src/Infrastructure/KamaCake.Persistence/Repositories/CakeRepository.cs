using KamaCake.Application.Interfaces.Repository;
using KamaCake.Domain.Entities;
using KamaCake.Persistence.Context;

namespace KamaCake.Persistence.Repositories
{
    public class CakeRepository:GenericRepository<Cake>,ICakeRepository
    {

        public CakeRepository(ApplicationDbContext context):base(context) { }
       
    }
}
