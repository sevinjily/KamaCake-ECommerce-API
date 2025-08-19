using KamaCake.Application.Interfaces.Repository;
using KamaCake.Persistence.Context;
using KamaCake.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KamaCake.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            serviceCollection.AddTransient<ICakeRepository, CakeRepository>();
            serviceCollection.AddTransient<ICategoryRepository, CategoryRepository>();



        }
    }
}
