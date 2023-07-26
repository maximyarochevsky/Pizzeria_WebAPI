using MediatR;
using Pizzeria.Application.Sections.Queries.ViewModels;

namespace Pizzeria.Application.Sections.Queries.GetSectionById;

public class GetSectionByIdQuery: IRequest<SectionVm>
{
    public Guid Id { get; set; }
}

