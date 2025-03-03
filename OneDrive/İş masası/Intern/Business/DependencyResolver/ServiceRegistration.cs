using Business.Abstract;
using Business.Concrete;
using Business.Message.Abstract;
using Business.Message.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolver
{
    public static class ServiceRegistration
    {
        public static void AddBusinessService(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenManager>();
        }
    }
}
