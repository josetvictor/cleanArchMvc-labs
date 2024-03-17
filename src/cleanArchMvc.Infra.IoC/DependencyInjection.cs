using cleanArchMvc.Domain.Interfaces;
using cleanArchMvc.Infra.Data.Context;
using cleanArchMvc.Infra.Data.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace cleanArchMvc.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config) 
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(config.GetConnectionString("DefaultConnection")
                , ServerVersion.AutoDetect(config.GetConnectionString("DefaultConnection"))
                , b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
