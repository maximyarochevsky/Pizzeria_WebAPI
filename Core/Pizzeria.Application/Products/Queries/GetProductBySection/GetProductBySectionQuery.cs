using ErrorOr;
using MediatR;
using Pizzeria.Application.Products.Queries.ViewModels;

namespace Pizzeria.Application.Products.Queries.GetProductBySection;

public record GetProductBySectionQuery(
    Guid SectionId) : IRequest<ErrorOr<ListProductsVm>>;


