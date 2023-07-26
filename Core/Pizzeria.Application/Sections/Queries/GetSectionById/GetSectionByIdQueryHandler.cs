using AutoMapper;
using MediatR;
using Pizzeria.Application.Interfaces;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Application.Sections.Queries.ViewModels;

namespace Pizzeria.Application.Sections.Queries.GetSectionById;

public class GetSectionByIdQueryHandler : IRequestHandler<GetSectionByIdQuery, SectionVm>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetSectionByIdQueryHandler(IPizzeriaDbContext dbContext, IMapper mapper, IUnitOfWork unitOfWork)
        => (_mapper, _unitOfWork) = (mapper, unitOfWork);

    public async Task<SectionVm> Handle(GetSectionByIdQuery request, CancellationToken cancellationToken)
    {
        var section = await _unitOfWork.Sections.GetSectionById(request.Id);

        if (section == null)
            throw new ArgumentException();

        return _mapper.Map<SectionVm>(section);
    }
    
    
}


