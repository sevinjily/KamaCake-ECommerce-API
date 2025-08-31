using FluentValidation;
using KamaCake.Application.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Reflection;

namespace KamaCake.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationRegistration(this IServiceCollection services)
        {
            var assm = Assembly.GetExecutingAssembly();
            services.AddMediatR(assm);
            services.AddAutoMapper(assm);

            // Bütün validator-ları avtomatik qeyd edir
            services.AddValidatorsFromAssembly(assm);
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("az");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RedisCacheBehavior<,>));
            

        }
    }
}
