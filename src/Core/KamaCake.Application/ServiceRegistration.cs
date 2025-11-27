using FluentValidation;
using KamaCake.Application.Bases;
using KamaCake.Application.Behaviors;
using KamaCake.Application.Exceptions;
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

            services.AddTransient<ExceptionMiddleware>();
            services.AddRulesFromAssemblyContaining(assm, typeof(BaseRule));


            // Bütün validator-ları avtomatik qeyd edir
            services.AddValidatorsFromAssembly(assm);
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("az");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RedisCacheBehavior<,>));
        }


            private static IServiceCollection AddRulesFromAssemblyContaining(this IServiceCollection services, Assembly assembly, Type type)

        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var item in types)
            {
                services.AddTransient(item);
            }

            return services;
        }
    }
    }

