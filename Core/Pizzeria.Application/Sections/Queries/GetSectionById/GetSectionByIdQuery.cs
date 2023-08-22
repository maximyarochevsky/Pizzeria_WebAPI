using ErrorOr;
using MediatR;
using Pizzeria.Application.Sections.Queries.ViewModels;

namespace Pizzeria.Application.Sections.Queries.GetSectionById;

public record GetSectionByIdQuery(
    Guid Id): IRequest<ErrorOr<SectionVm>>;

