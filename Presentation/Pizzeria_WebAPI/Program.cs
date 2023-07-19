using System.Reflection;
using Pizzeria.Application;
using Pizzeria.Application.Common.Mappings;
using Pizzeria.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Pizzeria.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(); 

services.AddApplication().AddInfrastructure(builder.Configuration);

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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
