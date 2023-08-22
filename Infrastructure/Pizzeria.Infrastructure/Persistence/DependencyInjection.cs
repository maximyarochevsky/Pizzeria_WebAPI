using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Pizzeria.Application.Interfaces;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Infrastructure.Persistence.Repositories;
using Pizzeria.Application.Interfaces.Authentication;
using Pizzeria.Infrastructure.Authentication;
using Pizzeria.Application.Interfaces.Services;
using Pizzeria.Infrastructure.Persistence.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;

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
        services.AddScoped<ICartRepository, CartRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        var connectionString = configuration["DbConnection"];

        services.AddDbContext<PizzeriaDbContext>(options =>
            { options.UseNpgsql(connectionString); });

        services.AddScoped<IPizzeriaDbContext>(provider =>
            provider.GetService<PizzeriaDbContext>());

        services.AddAuth(configuration);
        services.AddTransient<IDbInitializer, DbInitializer>();


        return services;
    }

    public static IServiceCollection AddAuth(this IServiceCollection
        services, IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);
        services.AddSingleton(Options.Create(jwtSettings));

        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret))
            });

        return services;
    }
}
