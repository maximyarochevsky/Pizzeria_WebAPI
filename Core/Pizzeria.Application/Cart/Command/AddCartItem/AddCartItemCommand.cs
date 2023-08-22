using ErrorOr;
using MediatR;

namespace Pizzeria.Application.Cart.Command.AddCartItem;

public record AddCartItemCommand(
    Guid ProductId,
    int Quantity) : IRequest<ErrorOr<bool>>;


