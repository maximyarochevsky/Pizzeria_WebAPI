using MediatR;
using Pizzeria.Application.Products.Queries.ViewModels;

namespace Pizzeria.Application.Products.Queries.GetProductBySection;

public class GetProductBySectionQuery : IRequest<ListProductsVm>
{
    public Guid SectionId { get; set; }
}

