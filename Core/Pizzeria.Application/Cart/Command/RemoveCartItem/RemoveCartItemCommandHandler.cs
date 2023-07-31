using MediatR;
using Pizzeria.Application.Interfaces.Persistence;

namespace Pizzeria.Application.Cart.Command.RemoveCartItem;

public class RemoveCartItemCommandHandler : IRequestHandler<RemoveCartItemCommand, bool>
{
    public IUnitOfWork _unitOfWork;

    public RemoveCartItemCommandHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<bool> Handle(RemoveCartItemCommand request, CancellationToken cancellationToken)
    {
        if (request.ProductId == null)
            throw new ArgumentNullException(nameof(request.ProductId));

        bool result = _unitOfWork.Cart.RemoveCartItem(request.ProductId);

        return result;
    }
}
