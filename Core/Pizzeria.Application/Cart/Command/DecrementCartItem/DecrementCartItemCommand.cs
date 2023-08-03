using ErrorOr;
using MediatR;

namespace Pizzeria.Application.Cart.Command.DecrementCartItem;

public class DecrementCartItemCommand : IRequest<ErrorOr<bool>>
{
    public Guid ProductId { get; set; }
}
