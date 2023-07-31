using MediatR;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Cart.Command.AddCartItem;

public class AddCartItemCommandHandler : IRequestHandler<AddCartItemCommand, CartItem>
{
    public IUnitOfWork _unitOfWork;

    public AddCartItemCommandHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<CartItem> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
    {
        var cartItem = new CartItem()
        {
            ProductId = request.ProductId,
            Quantity = request.Quantity,
            Price = request.Quantity * _unitOfWork
            .Products
            .GetProductById(request.ProductId)
            .Result
            .Price,
        };

        bool result = _unitOfWork.Cart.AddCartItem(cartItem);

        return cartItem;
    }
}

