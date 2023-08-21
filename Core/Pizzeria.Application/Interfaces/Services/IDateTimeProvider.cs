namespace Pizzeria.Application.Interfaces.Services;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
