using KamaCake.Application.Behaviors;
using KamaCake.Application.Interfaces.RedisCahce;
using KamaCake.Application.Interfaces.Repository;
using KamaCake.Application.Interfaces.Tokens;
using KamaCake.Domain.Entities;
using KamaCake.Persistence.Context;
using KamaCake.Persistence.RedisCache;
using KamaCake.Persistence.Repositories;
using KamaCake.Persistence.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            serviceCollection.AddTransient<IUserRepository, UserRepository>();
            serviceCollection.AddTransient<ICartRepository,CartRepository>();
            serviceCollection.AddTransient<ICartItemRepository, CartItemRepository>();
            serviceCollection.AddTransient<IFavoriteRepository, FavoriteRepository>();  




            serviceCollection.Configure<RedisCacheSettings>(configuration.GetSection("RedisCacheSettings"));
            serviceCollection.AddTransient<IRedisCacheService, RedisCacheService>();

            serviceCollection.AddIdentityCore<User>(opt =>
            {

                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 2;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireDigit = false;
                opt.SignIn.RequireConfirmedEmail=false;
            }
            )
                .AddRoles<Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            serviceCollection.Configure<TokenSettings>(configuration.GetSection("JWT"));
            serviceCollection.AddTransient<ITokenService, TokenService>();

            serviceCollection.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
            {
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),
                    ValidateLifetime = true, // Prod-da true olmalıdır
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    ClockSkew = TimeSpan.FromMinutes(1),// 1 dəqiqə gecikməni kompensasiya edir
                };
                opt.Events = new JwtBearerEvents //unauthorize ucun xususi mesaj(401 mesajını fərdiləşdirmək)
                {
                    OnChallenge = context =>
                    {
                        context.HandleResponse();
                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        var result = System.Text.Json.JsonSerializer.Serialize(
                            new { message = "Cart yaratmaq üçün əvvəlcə login olun." });
                        return context.Response.WriteAsync(result);
                    }
                };
            });

                //Microsoft.Extensions.Caching.StackExchangeRedis yukle
            serviceCollection.AddStackExchangeRedisCache(opt =>
            {
                opt.Configuration = configuration["RedisCacheSettings:ConnectionString"];
                opt.InstanceName = configuration["RedisCacheSettings:InstanceName"];

            });

        }
    }
}
