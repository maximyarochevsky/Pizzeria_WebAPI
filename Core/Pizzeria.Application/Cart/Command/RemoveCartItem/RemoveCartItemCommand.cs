using ErrorOr;
using MediatR;

namespace Pizzeria.Application.Cart.Command.RemoveCartItem;

public class RemoveCartItemCommand : IRequest<ErrorOr<bool>>
{
    public Guid ProductId { get; set; }
}
