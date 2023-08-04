using AutoMapper;
using ErrorOr;
using MediatR;
using Pizzeria.Application.Common.Exceptions;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Application.Orders.Queries.ViewModels;
using Pizzeria.Application.Products.Queries.ViewModels;

namespace Pizzeria.Application.Orders.Queries.GetAllOrders;

public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, ErrorOr<ListOrdersVm>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllOrdersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    => (_unitOfWork, _mapper) = (unitOfWork, mapper);

    public async Task<ErrorOr<ListOrdersVm>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _unitOfWork.Orders.GetAllOrders();

        if (orders is null)
            return new ErrorOr<ListOrdersVm>();

        var ordersVm = orders.Select(order => new OrderVm()
        {
            TotalPrice = order.TotalPrice,
            Phone = order.Phone,
            Address = order.Address,
            Date = order.Date,
            Description = order.Description,

            OrderItems = new List<OrderItemVm>(
                 order.OrderItems.Select(x => new OrderItemVm()
                 {
                     Price = x.Price,
                     Product = _mapper.Map<ProductDetailsVm>(x.Product),
                     Quantity = x.Quantity,
                 })
            ).ToList()
        }).ToList();


        return new ListOrdersVm() { Orders = ordersVm };
    }
}
