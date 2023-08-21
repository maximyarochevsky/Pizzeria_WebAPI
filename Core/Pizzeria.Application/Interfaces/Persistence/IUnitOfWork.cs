namespace Pizzeria.Application.Interfaces.Persistence;

public interface IUnitOfWork
{
    IOrderItemRepository OrderItems { get;}
    IOrderRepository Orders { get; }
    IProductRepository Products { get; }
    ISectionRepository Sections { get; }
    ICartRepository Cart { get; }
    IUserRepository Users { get; }

    Task<bool> CompleteAsync();
}

