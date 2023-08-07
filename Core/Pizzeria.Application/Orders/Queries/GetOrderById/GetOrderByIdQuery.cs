using ErrorOr;
using MediatR;
using Pizzeria.Application.Orders.Queries.ViewModels;

namespace Pizzeria.Application.Orders.Queries.GetOrderById;

public class GetOrderByIdQuery : IRequest<ErrorOr<OrderVm>>
{
    public Guid Id { get; set; }
}
