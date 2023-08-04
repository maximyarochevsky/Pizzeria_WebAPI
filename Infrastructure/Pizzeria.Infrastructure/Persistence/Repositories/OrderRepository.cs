using Microsoft.EntityFrameworkCore;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Application.Orders.Queries.ViewModels;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Infrastructure.Persistence.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(PizzeriaDbContext dbContext):base(dbContext)
    {
    }

    public Task<List<Order>> GetAllOrders()
    {
        return _dbContext.Orders.Include(o => o.OrderItems).ToListAsync();
    }

    public Task<Order> GetOrderById(Guid id)
    {
        return _dbContext.Orders.Include(o => o.OrderItems).FirstOrDefaultAsync(o => o.Id == id);
    }
}

