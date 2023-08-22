using ErrorOr;
using MediatR;
using Pizzeria.Application.Orders.Queries.ViewModels;

namespace Pizzeria.Application.Orders.Queries.GetOrderById;

public record GetOrderByIdQuery(
    Guid Id) : IRequest<ErrorOr<OrderVm>>;

