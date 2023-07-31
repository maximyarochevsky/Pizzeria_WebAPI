using MediatR;

namespace Pizzeria.Application.Cart.Command.DecrementCartItem;

public class DecrementCartItemCommand : IRequest<bool>
{
    public Guid ProductId { get; set; }
}
