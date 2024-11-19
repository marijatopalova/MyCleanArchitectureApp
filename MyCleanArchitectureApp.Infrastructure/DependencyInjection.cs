using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyCleanArchitectureApp.Domain.Interfaces;
using MyCleanArchitectureApp.Infrastructure.Data;
using MyCleanArchitectureApp.Infrastructure.Repositories;

namespace MyCleanArchitectureApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("Database")));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductsRepository>();

            return services;
        }
    }
}
