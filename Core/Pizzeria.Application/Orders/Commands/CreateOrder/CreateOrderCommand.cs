using ErrorOr;
using MediatR;

namespace Pizzeria.Application.Orders.Commands.CreateOrder;

public record CreateOrderCommand(
    string Address,
    string Phone,
    string Description
    ) : IRequest<ErrorOr<bool>>;

