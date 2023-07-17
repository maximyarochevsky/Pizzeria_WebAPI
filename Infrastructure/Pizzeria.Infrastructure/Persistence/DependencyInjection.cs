using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Pizzeria.Application.Interfaces;

namespace Pizzeria.Infrastructure.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection
        services, IConfiguration configuration)
    {
        var connectionString = configuration["DbConnection"];

        services.AddDbContext<PizzeriaDbContext>(options => 
            { options.UseNpgsql(connectionString); });

        services.AddScoped<IPizzeriaDbContext>(provider =>
            provider.GetService<PizzeriaDbContext>());

        return services;
    }
}

