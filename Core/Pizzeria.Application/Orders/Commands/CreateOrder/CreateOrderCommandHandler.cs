using AutoMapper;
using MediatR;
//using Pizzeria.Application.Interfaces.Persistence;
//using Pizzeria.Domain.Entities;

//namespace Pizzeria.Application.Orders.Commands.CreateOrder;

//public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
//{
//    private readonly IMapper _mapper;
//    private readonly IUnitOfWork _unitOfWork;

//    public Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
//    {
//        var orderItems = request
//            .Products
//            .Select(p => new OrderItem()
//        {
//                Price = p.Price,
//                Quantity = 
//        }).ToList();
//        var order = new Order
//        {
//            Description = request.Description,
//            Address = request.Address,
//            Phone = request.Phone,
//            Date = DateTimeOffset.Now,

//        }
//    }
//}

