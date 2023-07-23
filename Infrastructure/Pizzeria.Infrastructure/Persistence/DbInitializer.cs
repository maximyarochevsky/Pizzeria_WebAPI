using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pizzeria.Application.Interfaces;
using Pizzeria.Domain.Entities;
using System.Threading.Channels;

namespace Pizzeria.Infrastructure.Persistence;

public class DbInitializer : IDbInitializer
{
    //private readonly ILogger<DbInitializer> _logger;
    private readonly PizzeriaDbContext _dbContext;
    public DbInitializer(PizzeriaDbContext dbContext/*, Logger<DbInitializer> logger*/)
    {
        _dbContext = dbContext;
        //_logger = logger;
    }

    public async Task<bool> RemoveAsync(CancellationToken token = default)
    {
        //_logger.LogInformation("Попытка удаления БД");

        var result = await _dbContext.Database.EnsureDeletedAsync(token).ConfigureAwait(false);
        //if (result)

        //    _logger.LogInformation("Удаление БД выполнено успешно");
        //else
        //    _logger.LogInformation("Удаление БД не требуется (отстутсвует)");
        return result;
    }

    public async Task InitializeAsync(bool RemoveBefore = false, CancellationToken token = default)
    {
        //_logger.LogInformation("Инициализация БД");

        if (RemoveBefore)
            await RemoveAsync(token).ConfigureAwait(false);

        var pending_migrations = await _dbContext.Database.GetPendingMigrationsAsync(token)
            .ConfigureAwait(false);

        if (pending_migrations.Any())
        {
            //_logger.LogInformation("Выполнение миграции БД...");

            await _dbContext.Database.MigrateAsync(token).ConfigureAwait(false);

            //_logger.LogInformation("Выполнение миграции БД выполнено успешно");
        }

        await _dbContext.Database.MigrateAsync(token).ConfigureAwait(false);

        await InitializeProductsAsync(token).ConfigureAwait(false);
    }


    public async Task InitializeProductsAsync(CancellationToken token)
    {

        if (_dbContext.Sections.Any())
        {
            //_logger.LogInformation("Инициализация данных БД не требуется");
            return;
        }

        Section Sweet = new Section()
        {
            Id = Guid.NewGuid(),
            Name = "Сладкие",
        };
        Section Meat = new Section()
        {
            Id = Guid.NewGuid(),
            Name = "Мясные",
        };
        Section Vegetarian = new Section()
        {
            Id = Guid.NewGuid(),
            Name = "Вегетарианские",
        };

        Product MargaritaPizza = new Product()
        {
            Id = Guid.NewGuid(),
            Name = "Маргарита",
            Price = 599,
            Description = "Состав: сыр Моцарелла, томаты, томатный соус",
            Section = Vegetarian,
        };

        Product PepperoniPizza = new Product()
        {
            Id = Guid.NewGuid(),
            Name = "Пепперони",
            Price = 799,
            Description = "Состав: пепперони, увеличенная порция моцареллы, фирменный томатный соус",
            Section = Meat,
        };

        Product MeatPizza = new Product()
        {
            Id = Guid.NewGuid(),
            Name = "Мясная",
            Price = 799,
            Description = "Состав: цыпленок, ветчина, пикантная пепперони, острая чоризо, Моцарелла, фирменный томатный соус",
            Section = Meat,
        };

        Product CheesePizza = new Product()
        {
            Id = Guid.NewGuid(),
            Name = "Сырная",
            Price = 599,
            Description = "Состав: Моцарелла, сыры чеддер и пармезан, фирменный соус альфредо",
            Section = Vegetarian,
        };

        Product SpicyPizza = new Product()
        {
            Id = Guid.NewGuid(),
            Name = "Сладкая",
            Price = 699,
            Description = "Состав: карамельная начинка, фруктовое ассорти, сахарная пудра",
            Section = Sweet,
        };

        await using (await _dbContext.Database.BeginTransactionAsync(token))
        {
            await _dbContext.Sections.AddRangeAsync(Sweet, Meat, Vegetarian);
            await _dbContext.Products
                .AddRangeAsync(MargaritaPizza, PepperoniPizza, MeatPizza, CheesePizza, SpicyPizza);

            await _dbContext.SaveChangesAsync(token);

            await _dbContext.Database.CommitTransactionAsync(token);
        }

        //_logger.LogInformation("Инициализаиця тестовых данных БД выполнена успешно");
    }
}