using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Pizzeria.Application.Interfaces;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Infrastructure.Persistence.Repositories;

namespace Pizzeria.Infrastructure.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection
        services, IConfiguration configuration)
    {
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        services.AddScoped<ISectionRepository, SectionRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        var connectionString = configuration["DbConnection"];

        services.AddDbContext<PizzeriaDbContext>(options =>
            { options.UseNpgsql(connectionString); });

        services.AddScoped<IPizzeriaDbContext>(provider =>
            provider.GetService<PizzeriaDbContext>());


        services.AddTransient<IDbInitializer, DbInitializer>();


        return services;
    }
}

