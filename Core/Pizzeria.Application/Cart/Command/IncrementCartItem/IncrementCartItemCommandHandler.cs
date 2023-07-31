using MediatR;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Cart.Command.IncrementCartItem;

public class IncrementCartItemCommandHandler : IRequestHandler<IncrementCartItemCommand, bool>
{
    public IUnitOfWork _unitOfWork;

    public IncrementCartItemCommandHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<bool> Handle(IncrementCartItemCommand request, CancellationToken cancellationToken)
    {
        if(request.ProductId == null)
            throw new ArgumentNullException(nameof(request.ProductId));

        bool result = _unitOfWork.Cart.IncrementCartItem(request.ProductId);

        return result;
    }
}
