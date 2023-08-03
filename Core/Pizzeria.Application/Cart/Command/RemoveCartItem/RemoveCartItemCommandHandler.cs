using ErrorOr;
using MediatR;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Application.Common.Exceptions;

namespace Pizzeria.Application.Cart.Command.RemoveCartItem;

public class RemoveCartItemCommandHandler : IRequestHandler<RemoveCartItemCommand, ErrorOr<bool>>
{
    public IUnitOfWork _unitOfWork;

    public RemoveCartItemCommandHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<ErrorOr<bool>> Handle(RemoveCartItemCommand request, CancellationToken cancellationToken)
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

        bool result = _unitOfWork.Cart.RemoveCartItem(request.ProductId);

        return result;
    }
}
