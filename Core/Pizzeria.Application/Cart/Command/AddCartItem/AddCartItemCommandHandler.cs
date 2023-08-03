using ErrorOr;
using MediatR;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Domain.Entities;
using Pizzeria.Application.Common.Exceptions;

namespace Pizzeria.Application.Cart.Command.AddCartItem;

public class AddCartItemCommandHandler : IRequestHandler<AddCartItemCommand, ErrorOr<bool>>
{
    public IUnitOfWork _unitOfWork;

    public AddCartItemCommandHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<ErrorOr<bool>> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(request.ProductId.ToString(), out _))
        {
            return Errors.Product.InvalidId;
        }

        var entity = await _unitOfWork.Products.GetProductById(request.ProductId);

        if (entity is null)
        {
            return Errors.Product.NotFound;
        }

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

        return result;
    }
}

