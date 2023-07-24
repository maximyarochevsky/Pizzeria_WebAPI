using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Interfaces.Persistence;

public interface IOrderItemRepository
{
    Task<List<OrderItem>> GetAllOrderItemsByOrderId();
}

