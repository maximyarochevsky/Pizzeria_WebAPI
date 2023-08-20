using AutoMapper;
using ErrorOr;
using MediatR;
using Pizzeria.Application.Common.Exceptions;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, ErrorOr<bool>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateOrderCommandHandler(IUnitOfWork unitOfWork)
    {
            _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<bool>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Cart cart = await _unitOfWork.Cart.GetCart();

        var orderItems = await Task.WhenAll(cart.Items.Select(async item =>
        {
            var product = await _unitOfWork.Products.GetProductById(item.ProductId);
            return new OrderItem()
            {
                Price = item.Price,
                Quantity = item.Quantity,
                Product = product,
            };
        }));

        var orderItemsList = orderItems.ToList();

        if (orderItemsList.Count < 1)
        {
            return Errors.Order.NullItems;
        }

        var order = new Order
        {
            Description = request.Description,
            Address = request.Address,
            Phone = request.Phone,
            Date = DateTime.UtcNow.AddHours(3),
            OrderItems = orderItemsList,
            TotalPrice = cart.TotalPrice,
        };

        var result =  await _unitOfWork.Orders.Add(order);
        await _unitOfWork.CompleteAsync();

        _unitOfWork.Cart.ClearCart();

        return result;
    }
}

