using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Interfaces.Persistence;

public interface IOrderRepository
{
    Task<Order> GetOrderById(Guid id);
    Task<List<Order>> GetAllOrders(Guid id);
}

