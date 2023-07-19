using MediatR;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Description { get; set; }
}

