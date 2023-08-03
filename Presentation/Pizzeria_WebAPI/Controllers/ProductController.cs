using AutoMapper;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Application.Products.Queries.GetAllProducts;
using Pizzeria.Application.Products.Queries.GetProductBySection;
using Pizzeria.Application.Products.Queries.GetProductDetails;
using Pizzeria.Application.Products.Queries.ViewModels;
using Pizzeria.Contracts.Product.Get;

namespace Pizzeria_WebAPI.Controllers;


[Route("api/[controller]/[action]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public ProductController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("byId/{id}")]
    public async Task<IActionResult> GetProductDetails(Guid id)
    {
        var query = new GetProductDetailsQuery
        {
            Id = id
        };
        var vm = await _mediator.Send(query);

        return vm.Match(
                vm => Ok(_mapper.Map<GetProductDetailsResponse>(vm)),
                errors => Problem("Ошибка"));
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllProducts()
    {
        var query = new GetAllProductsQuery();

        var vm = await _mediator.Send(query);

        return vm.Match(
                vm => Ok(_mapper.Map<GetProductsListResponse>(vm)),
                errors => Problem("Ошибка"));
    }

    [HttpGet("bySection/{sectionId}")]

    public async Task<IActionResult> GetProductsBySection(Guid sectionId)
    {
        var query = new GetProductBySectionQuery()
        {
            SectionId = sectionId,
        };

        var vm = await _mediator.Send(query);

        return vm.Match(
                vm => Ok(_mapper.Map<GetProductsListResponse>(vm)),
                errors => Problem("Ошибка"));
    }

}

