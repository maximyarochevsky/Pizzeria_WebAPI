using ErrorOr;
using MediatR;
using Pizzeria.Application.Products.Queries.ViewModels;

namespace Pizzeria.Application.Products.Queries.GetProductBySection;

public class GetProductBySectionQuery : IRequest<ErrorOr<ListProductsVm>>
{
    public Guid SectionId { get; set; }
}

