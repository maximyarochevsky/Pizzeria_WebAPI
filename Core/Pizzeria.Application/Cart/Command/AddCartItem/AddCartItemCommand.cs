using ErrorOr;
using MediatR;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Cart.Command.AddCartItem;

public class AddCartItemCommand : IRequest<ErrorOr<bool>>
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
