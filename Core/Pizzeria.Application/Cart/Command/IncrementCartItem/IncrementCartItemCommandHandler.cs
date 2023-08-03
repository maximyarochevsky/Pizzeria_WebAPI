using ErrorOr;
using MediatR;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Domain.Entities;
using Pizzeria.Application.Common.Exceptions;

namespace Pizzeria.Application.Cart.Command.IncrementCartItem;

public class IncrementCartItemCommandHandler : IRequestHandler<IncrementCartItemCommand, ErrorOr<bool>>
{
    public IUnitOfWork _unitOfWork;

    public IncrementCartItemCommandHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<ErrorOr<bool>> Handle(IncrementCartItemCommand request, CancellationToken cancellationToken)
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

        bool result = _unitOfWork.Cart.IncrementCartItem(request.ProductId);

        return result;
    }
}
