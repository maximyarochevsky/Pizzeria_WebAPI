using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Application.Products.Queries.GetAllProducts;
using Pizzeria.Application.Products.Queries.GetProductBySection;
using Pizzeria.Application.Products.Queries.GetProductDetails;
using Pizzeria.Application.Products.Queries.ViewModels;

namespace Pizzeria_WebAPI.Controllers;


[Route("api/[controller]/[action]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDetailsVm>> GetProductDetails(Guid id)
    {
        var query = new GetProductDetailsQuery
        {
            Id = id
        };
        var vm = await _mediator.Send(query);

        return Ok(vm);
    }

    [HttpGet("{all}")]
    public async Task<ActionResult<ListProductsVm>> GetAllProducts()
    {
        var query = new GetAllProductsQuery();

        var vm = await _mediator.Send(query);

        return Ok(vm);
    }

    [HttpGet("{bySection}")]

    public async Task<ActionResult<ListProductsVm>> GetProductsBySection(Guid sectionId)
    {
        var query = new GetProductBySectionQuery()
        {
            SectionId = sectionId,
        };

        var vm = await _mediator.Send(query);

        return Ok(vm);
    }

}

