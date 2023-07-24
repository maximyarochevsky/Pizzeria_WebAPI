using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Interfaces.Persistence;

public interface IOrderRepository
{
    Task<Order> GetOrderById(int id);
    Task<List<Order>> GetAllOrders(int id);
}

