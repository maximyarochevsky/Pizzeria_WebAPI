using ErrorOr;
using MediatR;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Cart.Command.IncrementCartItem;

public class IncrementCartItemCommand : IRequest<ErrorOr<bool>>
{
    public Guid ProductId { get; set; }
}
