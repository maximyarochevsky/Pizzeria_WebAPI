using MediatR;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Cart.Command;

public class AddCartItemCommandHandler : IRequestHandler<AddCartItemCommand, CartItem>
{
    public IUnitOfWork _unitOfWork;

    public AddCartItemCommandHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<CartItem> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
    {
        var cartItem = new CartItem()
        {
            ProductId = request.Product.Id,
            Quantity = request.Quantity,
        };

        _unitOfWork.Cart.AddCartItem(cartItem);

        return cartItem;
    }
}

