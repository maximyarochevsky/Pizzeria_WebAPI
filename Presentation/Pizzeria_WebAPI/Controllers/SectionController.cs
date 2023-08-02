using AutoMapper;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Application.Sections.Queries.GetAllSections;
using Pizzeria.Application.Sections.Queries.GetSectionById;
using Pizzeria.Application.Sections.Queries.ViewModels;
using Pizzeria.Contracts.Product.Get;
using Pizzeria.Contracts.Section.Get;

namespace Pizzeria_WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class SectionController: ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public SectionController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ErrorOr<SectionVm>>> GetSectionById(Guid id)
    {
        var query = new GetSectionByIdQuery()
        {
            Id = id,
        };

        var vm = await _mediator.Send(query);

        return vm.Match(
                vm => Ok(_mapper.Map<GetSectionByIdResponse>(vm)),
                errors => Problem("Ошибка"));
    }

    [HttpGet("all")]
    public async Task<ActionResult<ErrorOr<ListSectionsVm>>> GetAllSections()
    {
        var query = new GetAllSectionsQuery();

        var vm = await _mediator.Send(query);

        return vm.Match(
                vm => Ok(_mapper.Map<GetSectionListResponse>(vm)),
                errors => Problem("Ошибка"));
    }
}

