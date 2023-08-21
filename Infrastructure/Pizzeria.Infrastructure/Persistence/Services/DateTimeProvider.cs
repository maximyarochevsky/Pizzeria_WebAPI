using Pizzeria.Application.Interfaces.Services;

namespace Pizzeria.Infrastructure.Persistence.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
