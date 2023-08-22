using ErrorOr;
using MediatR;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Cart.Command.IncrementCartItem;

public record IncrementCartItemCommand(
   Guid ProductId) : IRequest<ErrorOr<bool>>;

