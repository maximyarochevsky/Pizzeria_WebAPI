using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Application.Sections.Queries.GetAllSections;
using Pizzeria.Application.Sections.Queries.GetSectionById;
using Pizzeria.Application.Sections.Queries.ViewModels;
using Pizzeria.Domain.Entities;

namespace Pizzeria_WebAPI.Tests;

public class SectionsTests
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly IMapper _mapper;

    public SectionsTests()
    {
        _unitOfWork = Substitute.For<IUnitOfWork>();

        var config = new MapperConfiguration(cfg =>
            cfg.AddProfile<Mappings>());

        _mapper = config.CreateMapper();
    }

    [Fact]
    public void GetSectionById_SectionDTO_Test()
    {
        // Arrange
        var queryHandler = new GetSectionByIdQueryHandler(_mapper, _unitOfWork);

        var sweet = new Section()
        {
            Id = Guid.Empty,
            Name = "Сладкие",
        };

        var sweetExpected = new SectionVm()
        {
            Name = "Сладкие",
        };

        _unitOfWork.Sections.GetSectionById(Guid.Empty).Returns(sweet);
        
        var query = new GetSectionByIdQuery(Guid.Empty);

        // Act
        var result = queryHandler.Handle(query, new CancellationToken());

        // Assert
        result.Result.Value.Should().BeEquivalentTo(sweetExpected);
    }

    [Fact]
    public void GetAllSections_SectionsListDTO_Test()
    {
        // Arrange
        var queryHandler = new GetAllSectionsQueryHandler(_mapper, _unitOfWork);

        var sections = new List<Section>()
        {
            new Section()
            {
                Id = Guid.NewGuid(),
                Name = "Сладкие",
            },
            new Section()
            {
                Id = Guid.NewGuid(),
                Name = "Мясные",
            },
            new Section()
            {
                Id = Guid.NewGuid(),
                Name = "Вегетарианские",
            },
        };

        var sectionsVm = new ListSectionsVm(new List<SectionVm>()
        {
            new SectionVm()
            {
                Name = "Сладкие",
            },
            new SectionVm()
            {
                Name = "Мясные",
            },
            new SectionVm()
            {
                Name = "Вегетарианские",
            },
        });

        _unitOfWork.Sections.GetAllSections().Returns(sections);

        var query = new GetAllSectionsQuery();

        // Act
        var result = queryHandler.Handle(query, new CancellationToken());
        
        // Assert
        result.Result.Value.ListSections.Should().BeEquivalentTo(sectionsVm.ListSections, options => options);
    }
}
