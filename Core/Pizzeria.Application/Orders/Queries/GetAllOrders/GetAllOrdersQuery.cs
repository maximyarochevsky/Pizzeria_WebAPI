using ErrorOr;
using MediatR;
using Pizzeria.Application.Orders.Queries.ViewModels;

namespace Pizzeria.Application.Orders.Queries.GetAllOrders;

public record GetAllOrdersQuery : IRequest<ErrorOr<ListOrdersVm>>;

