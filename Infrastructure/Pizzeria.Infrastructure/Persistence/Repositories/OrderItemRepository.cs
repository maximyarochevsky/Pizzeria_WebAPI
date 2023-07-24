using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Infrastructure.Persistence.Repositories;

public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(PizzeriaDbContext dbContext):base(dbContext)
    {
    }

    public Task<List<OrderItem>> GetAllOrderItemsByOrderId()
    {
        throw new NotImplementedException();
    }
}

