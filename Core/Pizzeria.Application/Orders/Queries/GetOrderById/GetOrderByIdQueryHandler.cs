using AutoMapper;
using ErrorOr;
using MediatR;
using Pizzeria.Application.Common.Exceptions;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Application.Orders.Queries.ViewModels;

namespace Pizzeria.Application.Orders.Queries.GetOrderById;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, ErrorOr<OrderVm>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetOrderByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    => (_unitOfWork, _mapper) = (unitOfWork, mapper);

    public async Task<ErrorOr<OrderVm>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(request.Id.ToString(), out Guid result))
        {
            return Errors.Order.InvalidId;
        }

        var order = await _unitOfWork.Orders.GetOrderById(request.Id);

        if (order == null)
            return Errors.Order.NotFound;

        return _mapper.Map<OrderVm>(order);
    }
}
