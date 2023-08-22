using ErrorOr;
using MediatR;
using Pizzeria.Application.Products.Queries.ViewModels;

namespace Pizzeria.Application.Products.Queries.GetProductDetails;

public record GetProductDetailsQuery(
    Guid Id) : IRequest<ErrorOr<ProductDetailsVm>>;
