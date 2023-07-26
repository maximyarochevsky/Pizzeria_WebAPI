using AutoMapper;
using MediatR;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Application.Interfaces;
using Pizzeria.Application.Sections.Queries.ViewModels;

namespace Pizzeria.Application.Sections.Queries.GetAllSections;

public class GetAllSectionsQueryHandler : IRequestHandler<GetAllSectionsQuery, ListSectionsVm>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSectionsQueryHandler(IPizzeriaDbContext dbContext, IMapper mapper, IUnitOfWork unitOfWork)
        => (_mapper, _unitOfWork) = (mapper, unitOfWork);

    public async Task<ListSectionsVm> Handle(GetAllSectionsQuery request, CancellationToken cancellationToken)
    {
        var sections = await _unitOfWork.Sections.GetAllSections();

        if(sections == null)
            throw new ArgumentNullException(nameof(sections));

        var allSections = sections.Select(s => new SectionVm()
        {
            Name = s.Name,
        }).ToList();

        return new ListSectionsVm { ListSections = allSections };
    }
}

