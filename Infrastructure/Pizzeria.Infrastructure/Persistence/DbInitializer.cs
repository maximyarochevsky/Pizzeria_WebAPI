namespace Pizzeria.Infrastructure.Persistence;

public class DbInitializer
{
    public static void Initialize(PizzeriaDbContext context)
    {
        context.Database.EnsureCreated();
    }
}