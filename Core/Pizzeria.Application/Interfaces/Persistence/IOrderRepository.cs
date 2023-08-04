using Microsoft.EntityFrameworkCore;
using Pizzeria.Application.Orders.Queries.ViewModels;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Interfaces.Persistence;

public interface IOrderRepository : IGenericRepository<Order>
{
    Task<Order> GetOrderById(Guid id);
    Task<List<Order>> GetAllOrders(); 
}

