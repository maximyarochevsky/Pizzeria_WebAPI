using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Application.Sections.Queries.GetAllSections;
using Pizzeria.Application.Sections.Queries.GetSectionById;
using Pizzeria.Contracts.Section.Get;

namespace Pizzeria_WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class SectionController: ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public SectionController(IMediator mediator, IMapper mapper)
    => (_mediator, _mapper) = (mediator, mapper);


    [HttpGet("{id}")]
    public async Task<IActionResult> GetSectionById(Guid id)
    {
        var query = new GetSectionByIdQuery(id);

        var vm = await _mediator.Send(query);

        return vm.MatchFirst(
                vm => Ok(_mapper.Map<GetSectionByIdResponse>(vm)),
                error => Problem(title: error.Description));
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllSections()
    {
        var query = new GetAllSectionsQuery();

        var vm = await _mediator.Send(query);

        return vm.MatchFirst(
                vm => Ok(_mapper.Map<GetSectionListResponse>(vm)),
                error => Problem(title: error.Description));
    }
}

