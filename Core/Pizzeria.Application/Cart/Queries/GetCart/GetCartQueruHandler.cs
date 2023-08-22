using MediatR;
using Pizzeria.Application.Interfaces.Persistence;
using ErrorOr;
using Pizzeria.Application.Common.Exceptions;
using AutoMapper;
using Pizzeria.Application.Cart.Queries.ViewModels;

namespace Pizzeria.Application.Cart.Queries.GetCart;

public class GetCartQueryHandler : IRequestHandler<GetCartQuery, ErrorOr<CartVm>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCartQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) =>
        (_unitOfWork, _mapper) = (unitOfWork, mapper);
    
    public async Task<ErrorOr<CartVm>> Handle(GetCartQuery request, CancellationToken cancellationToken)
    {
        var cart = await _unitOfWork.Cart.GetCart();

        if (cart is null)
            return Errors.Cart.NullCart;

        return _mapper.Map<CartVm>(cart);
    }
}
