using MediatR;
using Pizzeria.Application.Interfaces;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler : 
    IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly IPizzeriaDbContext _dbContext;

    public CreateOrderCommandHandler(IPizzeriaDbContext dbContext) =>
        _dbContext = dbContext;
    
        public async Task<Guid> Handle(CreateOrderCommand request,
        CancellationToken cancellationToken)
        {
            var order = new Order
            {
                UserId = request.UserId,
                Address = request.Address,
                Description = request.Description,
                Phone = request.Phone,
                Items = null,
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
            };

        return order.Id;
    }
}

