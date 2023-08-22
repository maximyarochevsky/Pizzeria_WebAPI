using ErrorOr;
using MediatR;

namespace Pizzeria.Application.Cart.Command.ClearCart;

public record ClearCartCommand() : IRequest<ErrorOr<bool>>;
