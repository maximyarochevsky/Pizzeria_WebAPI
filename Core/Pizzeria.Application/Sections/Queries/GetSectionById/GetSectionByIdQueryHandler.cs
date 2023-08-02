﻿using AutoMapper;
using ErrorOr;
using MediatR;
using Pizzeria.Application.Common.Exceptions;
using Pizzeria.Application.Interfaces;
using Pizzeria.Application.Interfaces.Persistence;
using Pizzeria.Application.Sections.Queries.ViewModels;

namespace Pizzeria.Application.Sections.Queries.GetSectionById;

public class GetSectionByIdQueryHandler : IRequestHandler<GetSectionByIdQuery, ErrorOr<ListSectionsVm>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetSectionByIdQueryHandler(IPizzeriaDbContext dbContext, IMapper mapper, IUnitOfWork unitOfWork)
        => (_mapper, _unitOfWork) = (mapper, unitOfWork);

    public async Task<ErrorOr<ListSectionsVm>> Handle(GetSectionByIdQuery request, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(request.Id.ToString(), out _))
            return Errors.Section.InvalidId;

        var section = await _unitOfWork.Sections.GetSectionById(request.Id);

        if (section == null)
            return Errors.Section.NotFound;

        return _mapper.Map<ListSectionsVm>(section);
    }
    
    
}


