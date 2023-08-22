using Pizzeria.Application;
using Pizzeria.Infrastructure.Persistence;
using Pizzeria.Application.Interfaces;
using Pizzeria_WebAPI;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

{ 
    services.AddSession();
    services.AddApplication()
        .AddInfrastructure(builder.Configuration)
        .AddPresentation(builder.Configuration);

    services.AddCors(options =>
    {
        options.AddPolicy("AllowAllHeaders", builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    });

    services.AddDistributedMemoryCache();
    services.AddHttpContextAccessor();
}

var app = builder.Build();

{
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

    app.UseSession();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
