using AutoMapper;
using FluentAssertions;
using MediatR;
using NSubstitute;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Application.Orders.Commands.CreateOrder;
using Pizzeria.Application.Orders.Queries.GetAllOrders;
using Pizzeria.Application.Orders.Queries.GetOrderById;
using Pizzeria.Application.Orders.Queries.ViewModels;
using Pizzeria.Application.Products.Queries.GetAllProducts;
using Pizzeria.Application.Products.Queries.ViewModels;
using Pizzeria.Domain.Entities;

namespace Pizzeria_WebAPI.Tests;

public class OrdersTests
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly IMapper _mapper;

    public OrdersTests()
    {
        _unitOfWork = Substitute.For<IUnitOfWork>();

        var config = new MapperConfiguration(cfg =>
            cfg.AddProfile<Mappings>());

        _mapper = config.CreateMapper();
    }

    [Fact]
    public void CreateOrder_StatusCode_Test()
    {
        var commandHandler = new CreateOrderCommandHandler(_unitOfWork, _mapper);

        Section Sweet = new Section()
        {
            Id = Guid.NewGuid(),
            Name = "Сладкие",
        };

        var product =
            new Product()
            {
                Id = Guid.Empty,
                Name = "Маргарита",
                Price = 599,
                Description = "Состав: сыр Моцарелла, томаты, томатный соус",
                Section = Sweet,
            };

        var order =
            new Order()
            {
                Id = Guid.Empty,
                TotalPrice = 10,
                Description = "",
                Address = "df",
                Phone = "3434",
                Date = DateTime.MinValue,
                OrderItems = new List<OrderItem>(),
            };

        _unitOfWork.Cart.GetCart().Returns(new Cart()
        {
            Items = new List<CartItem>()
            { new CartItem(),
            },
            TotalPrice = 100,
        });

        _unitOfWork.Products.GetProductById(Guid.Empty).Returns(product);

        var command = new CreateOrderCommand(order.Address, order.Phone, order.Description);

        var result = commandHandler.Handle(command, new CancellationToken());

        Assert.Equal(result.Result.Value, false);
    }

    [Fact]
    public void GetAllOrders_OrdersDTOList_Test()
    {
        // Arrange
        var queryHandler = new GetAllOrdersQueryHandler(_unitOfWork, _mapper);

        var ordersList = new List<Order>()
        {
            new Order()
            {
                TotalPrice = 10,
                Description = "",
                Address = "df",
                Phone = "3434",
                Date = DateTime.MinValue,
                OrderItems = new List<OrderItem>(),
            },
        };

        var exepctedOrdersVm = new List<OrderVm>()
        {
            new OrderVm()
            {
                TotalPrice = 10,
                Description = "",
                Address = "df",
                Phone = "3434",
                Date = DateTime.MinValue,
                OrderItems = null,
            },
        };

        var expectedListOrdersVm = new ListOrdersVm(exepctedOrdersVm);

        _unitOfWork.Orders.GetAllOrders().Returns(ordersList);

        var query = new GetAllOrdersQuery();

        // Act
        var result = queryHandler.Handle(query, new CancellationToken());

        // Assert
        result.Result.Value.Orders.Should().BeEquivalentTo(expectedListOrdersVm.Orders, options => options
            .ExcludingMissingMembers() // Игнорировать отсутствующие члены (поля)
            .Excluding(o => o.OrderItems));
    }

    [Fact]
    public void GetOrder_OrderDTO_Test()
    {
        // Arrange
        var queryHandler = new GetOrderByIdQueryHandler(_unitOfWork, _mapper);

        var order =
            new Order()
            {
                Id = Guid.Empty,
                TotalPrice = 10,
                Description = "",
                Address = "df",
                Phone = "3434",
                Date = DateTime.MinValue,
                OrderItems = new List<OrderItem>(),
            };

        var exepctedOrderVm = 
            new OrderVm()
            {
                TotalPrice = 10,
                Description = "",
                Address = "df",
                Phone = "3434",
                Date = DateTime.MinValue,
                OrderItems = null,
            };
    
        _unitOfWork.Orders.GetOrderById(Guid.Empty).Returns(order);

        var query = new GetOrderByIdQuery(Guid.Empty);

        // Act
        var result = queryHandler.Handle(query, new CancellationToken());

        // Assert
        result.Result.Value.Should().BeEquivalentTo(exepctedOrderVm, options => options
            .ExcludingMissingMembers() 
            .Excluding(o => o.OrderItems));

    }
}