using MediatR;
using Pizzeria.Application.Cart.Command.IncrementCartItem;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Application.Common.Exceptions;
using ErrorOr;

namespace Pizzeria.Application.Cart.Command.DecrementCartItem;

public class DecrementCartItemCommandHandler : IRequestHandler<DecrementCartItemCommand, ErrorOr<bool>>
{
    public IUnitOfWork _unitOfWork;

    public DecrementCartItemCommandHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<ErrorOr<bool>> Handle(DecrementCartItemCommand request, CancellationToken cancellationToken)
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

        bool result = _unitOfWork.Cart.DecrementCartItem(request.ProductId);

        return result;
    }
}

