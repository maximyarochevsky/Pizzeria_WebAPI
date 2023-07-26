using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Application.Sections.Queries.GetAllSections;
using Pizzeria.Application.Sections.Queries.GetSectionById;
using Pizzeria.Application.Sections.Queries.ViewModels;

namespace Pizzeria_WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class SectionController: ControllerBase
{
    private readonly IMediator _mediator;
    public SectionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SectionVm>> GetSectionById(Guid id)
    {
        var query = new GetSectionByIdQuery()
        {
            Id = id,
        };

        var vm = await _mediator.Send(query);

        return Ok(vm);
    }

    [HttpGet("{all}")]
    public async Task<ActionResult<ListSectionsVm>> GetAllSections()
    {
        var query = new GetAllSectionsQuery();

        var vm = await _mediator.Send(query);

        return Ok(vm);
    }
}

