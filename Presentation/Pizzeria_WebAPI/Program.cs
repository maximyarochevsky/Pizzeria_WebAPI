using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Application;
using Microsoft.Extensions.Configuration;
using Pizzeria.Application.Common.Mappings;
using Pizzeria.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Pizzeria.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddApplication();
var connectionString = builder.Configuration["DbConnection"];

services.AddControllers();

services.AddDbContext<PizzeriaDbContext>(options =>
    { options.UseNpgsql(connectionString); });

services.AddScoped<IPizzeriaDbContext>(provider =>
    provider.GetService<PizzeriaDbContext>());


services.AddTransient<IDbInitializer, DbInitializer>();
services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IPizzeriaDbContext).Assembly));
});

services.AddCors(options =>
{
    options.AddPolicy("AllowAllHeaders", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

await using (var scope = app.Services.CreateAsyncScope())
{
    var db_initializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
    await db_initializer.InitializeAsync(RemoveBefore: true).ConfigureAwait(true);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
