using MediatR;
using Pizzeria.Application.Products.Queries.ViewModels;

namespace Pizzeria.Application.Products.Queries.GetProductDetails;

public class GetProductDetailsQuery : IRequest<ProductDetailsVm>
{
    public Guid Id { get; set; }
}
