using ErrorOr;
using MediatR;
using Pizzeria.Application.Products.Queries.ViewModels;

namespace Pizzeria.Application.Products.Queries.GetProductDetails;

public class GetProductDetailsQuery : IRequest<ErrorOr<ProductDetailsVm>>
{
    public Guid Id { get; set; }
}
