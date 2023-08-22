using ErrorOr;
using MediatR;

namespace Pizzeria.Application.Cart.Command.RemoveCartItem;

public record RemoveCartItemCommand(
    Guid ProductId) : IRequest<ErrorOr<bool>>;

