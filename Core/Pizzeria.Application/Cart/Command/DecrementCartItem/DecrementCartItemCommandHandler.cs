using MediatR;
using Pizzeria.Application.Cart.Command.IncrementCartItem;
using Pizzeria.Application.Interfaces.Persistence;

namespace Pizzeria.Application.Cart.Command.DecrementCartItem;

public class DecrementCartItemCommandHandler : IRequestHandler<DecrementCartItemCommand, bool>
{
    public IUnitOfWork _unitOfWork;

    public DecrementCartItemCommandHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<bool> Handle(DecrementCartItemCommand request, CancellationToken cancellationToken)
    {
        if (request.ProductId == null)
            throw new ArgumentNullException(nameof(request.ProductId));

        bool result = _unitOfWork.Cart.DecrementCartItem(request.ProductId);

        return result;
    }
}

