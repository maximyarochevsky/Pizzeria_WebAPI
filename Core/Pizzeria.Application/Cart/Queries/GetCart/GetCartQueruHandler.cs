using MediatR;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Domain.Entities;


namespace Pizzeria.Application.Cart.Queries.GetCart;

public class GetCartQueryHandler : IRequestHandler<GetCartQuery, List<CartItem>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCartQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<List<CartItem>> Handle(GetCartQuery request, CancellationToken cancellationToken)
    {
        var list = await _unitOfWork.Cart.GetCart();

        if (list == null)
            throw new ArgumentNullException("list");

        return list;
    }
}
