using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Pizzeria.Application.Cart.Command.AddCartItem;
using Pizzeria.Application.Cart.Command.ClearCart;
using Pizzeria.Application.Cart.Command.DecrementCartItem;
using Pizzeria.Application.Cart.Command.IncrementCartItem;
using Pizzeria.Application.Cart.Queries.GetCart;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Domain.Entities;
using static Pizzeria.Application.Common.Exceptions.Errors;

namespace Pizzeria_WebAPI.Tests;

public class CartTests
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly IMapper _mapper;

    public CartTests()
    {
        _unitOfWork = Substitute.For<IUnitOfWork>();

        var config = new MapperConfiguration(cfg =>
            cfg.AddProfile<Mappings>());

        _mapper = config.CreateMapper();
    }

    [Fact]
    public void AddItem_NullException_False_Test()
    {
        var commandHandler = new AddCartItemCommandHandler(_unitOfWork);

        _unitOfWork.Cart.AddCartItem(new CartItem()).Returns(true);

        var command = new AddCartItemCommand(Guid.Empty, 6);

        var result = commandHandler.Handle(command, new CancellationToken());

        // Assert
        Assert.Equal(result.Result.Value, false);
    }

    [Fact]
    public void IncrementItem_StatusCode_Test()
    {
        var commandHandler = new IncrementCartItemCommandHandler(_unitOfWork);

        var Sweet = new Pizzeria.Domain.Entities.Section()
        {
            Id = Guid.NewGuid(),
            Name = "Сладкие",
        };

        var product =
           new Pizzeria.Domain.Entities.Product()
           {
               Id = Guid.Empty,
               Name = "Маргарита",
               Price = 599,
               Description = "Состав: сыр Моцарелла, томаты, томатный соус",
               Section = Sweet,
           };

        _unitOfWork.Cart.IncrementCartItem(Guid.Empty).Returns(true);
        _unitOfWork.Products.GetProductById(Guid.Empty).Returns(product);

        var command = new IncrementCartItemCommand(Guid.Empty);

        var result = commandHandler.Handle(command, new CancellationToken());

        // Assert
        Assert.Equal(result.Result.Value, true);
    }

    [Fact]
    public void DecrementItem_StatusCode_Test()
    {
        var commandHandler = new DecrementCartItemCommandHandler(_unitOfWork);

        var Sweet = new Pizzeria.Domain.Entities.Section()
        {
            Id = Guid.NewGuid(),
            Name = "Сладкие",
        };

        var product =
           new Pizzeria.Domain.Entities.Product()
           {
               Id = Guid.Empty,
               Name = "Маргарита",
               Price = 599,
               Description = "Состав: сыр Моцарелла, томаты, томатный соус",
               Section = Sweet,
           };

        _unitOfWork.Cart.DecrementCartItem(Guid.Empty).Returns(true);
        _unitOfWork.Products.GetProductById(Guid.Empty).Returns(product);

        var command = new DecrementCartItemCommand(Guid.Empty);

        var result = commandHandler.Handle(command, new CancellationToken());

        // Assert
        Assert.Equal(result.Result.Value, true);
    }

    [Fact]
    public void GetCart_CartDTO_Test()
    {
        var queryHandler = new GetCartQueryHandler(_unitOfWork, _mapper);

        var cart = new Pizzeria.Domain.Entities.Cart()
        {
            Items = new List<CartItem>()
            { new CartItem(),
            },
            TotalPrice = 100,
        };

        _unitOfWork.Cart.GetCart().Returns(cart);

        var query = new GetCartQuery();

        var result = queryHandler.Handle(query, new CancellationToken());

        // Assert
        result.Result.Value.Should().BeEquivalentTo(cart);
    }
}
