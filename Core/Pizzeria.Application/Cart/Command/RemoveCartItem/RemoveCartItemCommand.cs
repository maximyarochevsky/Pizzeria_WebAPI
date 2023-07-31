using MediatR;

namespace Pizzeria.Application.Cart.Command.RemoveCartItem;

public class RemoveCartItemCommand : IRequest<bool>
{
    public Guid ProductId { get; set; }
}
