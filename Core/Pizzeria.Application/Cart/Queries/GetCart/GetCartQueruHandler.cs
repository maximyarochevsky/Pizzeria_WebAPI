using MediatR;
using Pizzeria.Application.Interfaces.Persistence;


namespace Pizzeria.Application.Cart.Queries.GetCart;

public class GetCartQueryHandler : IRequestHandler<GetCartQuery, Domain.Entities.Cart>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCartQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Domain.Entities.Cart> Handle(GetCartQuery request, CancellationToken cancellationToken)
    {
        var cart = await _unitOfWork.Cart.GetCart();

        if (cart == null)
            throw new ArgumentNullException("list");

        return cart;
    }
}
