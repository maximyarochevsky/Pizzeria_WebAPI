using MediatR;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Cart.Command.IncrementCartItem;

public class IncrementCartItemCommand : IRequest<bool>
{
    public Guid ProductId { get; set; }
}
