using AutoMapper;
using MediatR;
using NSubstitute;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Application.Products.Queries.GetAllProducts;
using Pizzeria.Application.Products.Queries.ViewModels;
using Pizzeria.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizzeria.Application.Products.Queries.GetProductDetails;
using Pizzeria.Application.Products.Queries.GetProductBySection;

namespace Pizzeria_WebAPI.Tests;

public class ProductsTests
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly IMediator _mediator;

    private readonly IMapper _mapper;

    public ProductsTests()
    {
        _unitOfWork = Substitute.For<IUnitOfWork>();
        _mediator = Substitute.For<IMediator>();

        var config = new MapperConfiguration(cfg =>
            cfg.AddProfile<Mappings>());

        _mapper = config.CreateMapper();
    }

    [Fact]
    public void GetAllProducts_ProductsListDTO_Test()
    {
        // Arrange
        var queryHandler = new GetAllProductsQueryHandler(_unitOfWork, _mapper);

        Section Sweet = new Section()
        {
            Id = Guid.NewGuid(),
            Name = "Сладкие",
        };
        Section Meat = new Section()
        {
            Id = Guid.NewGuid(),
            Name = "Мясные",
        };
        Section Vegetarian = new Section()
        {
            Id = Guid.NewGuid(),
            Name = "Вегетарианские",
        };

        var productsList = new List<Product>()
        {
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Маргарита",
                Price = 599,
                Description = "Состав: сыр Моцарелла, томаты, томатный соус",
                Section = Vegetarian,
            },

            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Пепперони",
                Price = 799,
                Description = "Состав: пепперони, увеличенная порция моцареллы, фирменный томатный соус",
                Section = Meat,
            },

            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Мясная",
                Price = 799,
                Description = "Состав: цыпленок, ветчина, пикантная пепперони, острая чоризо, Моцарелла, фирменный томатный соус",
                Section = Meat,
            },
           
        };

        var exepctedProductsVm = new List<ProductDetailsVm>()
        {
            new ProductDetailsVm()
            {
                Id = Guid.NewGuid(),
                Name = "Маргарита",
                Price = 599,
                Description = "Состав: сыр Моцарелла, томаты, томатный соус",
                Section = null,
            },

            new ProductDetailsVm()
            {
                Id = Guid.NewGuid(),
                Name = "Пепперони",
                Price = 799,
                Description = "Состав: пепперони, увеличенная порция моцареллы, фирменный томатный соус",
                Section = null,
            },

            new ProductDetailsVm()
            {
                Id = Guid.NewGuid(),
                Name = "Мясная",
                Price = 799,
                Description = "Состав: цыпленок, ветчина, пикантная пепперони, острая чоризо, Моцарелла, фирменный томатный соус",
                Section = null,
            },

        };

        var expectedListProductsVm = new ListProductsVm(exepctedProductsVm);

        _unitOfWork.Products.GetAllProducts().Returns(productsList);

        var query = new GetAllProductsQuery();

        // Act
        var result = queryHandler.Handle(query, new CancellationToken());

        // Assert
        result.Result.Value.ListProducts.Should().BeEquivalentTo(expectedListProductsVm.ListProducts, options => options
            .ExcludingMissingMembers() // Игнорировать отсутствующие члены (поля)
            .Excluding(o => o.Id)
            .Excluding(o => o.Section));
    }

    [Fact]
    public void GetProductById_ProductDTO_Test()
    {
        // Arrange
        var queryHandler = new GetProductDetailsQueryHandler(_mapper, _unitOfWork);
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

        var exepcted =
            new ProductDetailsVm()
            {
                Id = Guid.NewGuid(),
                Name = "Маргарита",
                Price = 599,
                Description = "Состав: сыр Моцарелла, томаты, томатный соус",
                Section = "Сладкие",
            };

        _unitOfWork.Products.GetProductById(Guid.Empty).Returns(product);

        var query = new GetProductDetailsQuery(Guid.Empty);

        // Act
        var result = queryHandler.Handle(query, new CancellationToken());

        // Assert
        result.Result.Value.Should().BeEquivalentTo(exepcted, options => options
            .ExcludingMissingMembers() // Игнорировать отсутствующие члены (поля)
            .Excluding(o => o.Id)
            .Excluding(o => o.Section));
    }

    [Fact]
    public void GetProductBySection_ProductDTO_Test()
    {
        // Arrange
        var queryHandler = new GetProductBySectionQueryHandler(_mapper, _unitOfWork);
        Section Sweet = new Section()
        {
            Id = Guid.NewGuid(),
            Name = "Сладкие",
        };

        var productsList = new List<Product>()
        {
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Маргарита",
                Price = 599,
                Description = "Состав: сыр Моцарелла, томаты, томатный соус",
                Section = Sweet,
            },
        };

        var exepctedProductsVm = new List<ProductDetailsVm>()
        {
            new ProductDetailsVm()
            {
                Id = Guid.NewGuid(),
                Name = "Маргарита",
                Price = 599,
                Description = "Состав: сыр Моцарелла, томаты, томатный соус",
                Section = "Сладкие",
            },
        };

        var expectedListProductsVm = new ListProductsVm(exepctedProductsVm);

        _unitOfWork.Products.GetProductsBySection(Guid.Empty).Returns(productsList);

        var query = new GetProductBySectionQuery(Guid.Empty);

        // Act
        var result = queryHandler.Handle(query, new CancellationToken());

        // Assert
        result.Result.Value.ListProducts.Should().BeEquivalentTo(expectedListProductsVm.ListProducts, options => options
            .ExcludingMissingMembers() // Игнорировать отсутствующие члены (поля)
            .Excluding(o => o.Id)
            .Excluding(o => o.Section));
    }
}
