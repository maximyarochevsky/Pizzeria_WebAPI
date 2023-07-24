using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Infrastructure.Persistence.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(PizzeriaDbContext dbContext):base(dbContext)
    {
    }

    public Task<List<Order>> GetAllOrders(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Order> GetOrderById(Guid id)
    {
        throw new NotImplementedException();
    }
}

