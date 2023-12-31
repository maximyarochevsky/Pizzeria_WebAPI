﻿using ErrorOr;
using MediatR;
using Pizzeria.Application.Sections.Queries.ViewModels;

namespace Pizzeria.Application.Sections.Queries.GetAllSections;

public record GetAllSectionsQuery: IRequest<ErrorOr<ListSectionsVm>>;


