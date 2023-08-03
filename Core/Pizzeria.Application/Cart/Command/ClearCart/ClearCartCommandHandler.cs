using ErrorOr;
using MediatR;
using Pizzeria.Application.Interfaces.Persistence;

namespace Pizzeria.Application.Cart.Command.ClearCart;

public class ClearCartCommandHandler : IRequestHandler<ClearCartCommand, ErrorOr<bool>>
{
    public IUnitOfWork _unitOfWork;

    public ClearCartCommandHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<ErrorOr<bool>> Handle(ClearCartCommand request, CancellationToken cancellationToken)
    {
        var result = _unitOfWork.Cart.ClearCart();

        return result;
    }
}
