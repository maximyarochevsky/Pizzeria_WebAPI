using ErrorOr;
using MediatR;

namespace Pizzeria.Application.Cart.Command.DecrementCartItem;

public record DecrementCartItemCommand(
    Guid ProductId) : IRequest<ErrorOr<bool>>;

