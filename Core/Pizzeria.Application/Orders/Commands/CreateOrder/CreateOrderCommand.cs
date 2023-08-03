using ErrorOr;
using MediatR;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommand : IRequest<ErrorOr<bool>>
{
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Description { get; set; }
}

