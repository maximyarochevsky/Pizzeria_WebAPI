using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Application.Products.Queries.GetAllProducts;
using Pizzeria.Application.Products.Queries.GetProductBySection;
using Pizzeria.Application.Products.Queries.GetProductDetails;
using Pizzeria.Contracts.Product.Get;

namespace Pizzeria_WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public ProductController(IMediator mediator, IMapper mapper)
    => (_mediator, _mapper) = (mediator, mapper);


    [HttpGet("byId/{id}")]
    public async Task<IActionResult> GetProductDetails(Guid id)
    {
        var query = new GetProductDetailsQuery(id);

        var vm = await _mediator.Send(query);

        return vm.MatchFirst(
                vm => Ok(_mapper.Map<GetProductDetailsResponse>(vm)),
                error => Problem(title: error.Description));
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllProducts()
    {
        var query = new GetAllProductsQuery();

        var vm = await _mediator.Send(query);

        return vm.MatchFirst(
                vm => Ok(_mapper.Map<GetProductsListResponse>(vm)),
                error => Problem(title: error.Description));
    }

    [HttpGet("bySection/{sectionId}")]

    public async Task<IActionResult> GetProductsBySection(Guid sectionId)
    {
        var query = new GetProductBySectionQuery(sectionId);

        var vm = await _mediator.Send(query);

        return vm.MatchFirst(
                vm => Ok(_mapper.Map<GetProductsListResponse>(vm)),
                error => Problem(title: error.Description));
    }

}

