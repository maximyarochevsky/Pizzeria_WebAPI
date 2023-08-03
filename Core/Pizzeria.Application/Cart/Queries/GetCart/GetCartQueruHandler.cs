using MediatR;
using Pizzeria.Application.Interfaces.Persistence;
using ErrorOr;
using Pizzeria.Application.Common.Exceptions;

namespace Pizzeria.Application.Cart.Queries.GetCart;

public class GetCartQueryHandler : IRequestHandler<GetCartQuery, ErrorOr<Domain.Entities.Cart>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCartQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ErrorOr<Domain.Entities.Cart>> Handle(GetCartQuery request, CancellationToken cancellationToken)
    {
        var cart = await _unitOfWork.Cart.GetCart();

        if (cart is null)
            return Errors.Cart.NullCart;

        return cart;
    }
}
