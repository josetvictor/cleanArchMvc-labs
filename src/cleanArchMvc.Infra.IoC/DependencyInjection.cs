using cleanArchMvc.Application.Interfaces;
using cleanArchMvc.Application.Mapping;
using cleanArchMvc.Application.Services;
using cleanArchMvc.Domain.Interfaces;
using cleanArchMvc.Infra.Data.Context;
using cleanArchMvc.Infra.Data.Repositories;

using MediatR;

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

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var myHandlers = AppDomain.CurrentDomain.Load("cleanArchMvc.Application");
            services.AddMediatR(myHandlers);

            return services;
        }
    }
}
