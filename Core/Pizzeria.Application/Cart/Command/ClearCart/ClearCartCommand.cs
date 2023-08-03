using ErrorOr;
using MediatR;

namespace Pizzeria.Application.Cart.Command.ClearCart;

public class ClearCartCommand : IRequest<ErrorOr<bool>>
{
}
