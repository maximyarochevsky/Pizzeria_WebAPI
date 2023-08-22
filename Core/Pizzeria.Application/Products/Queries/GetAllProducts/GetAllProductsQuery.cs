using ErrorOr;
using MediatR;
using Pizzeria.Application.Products.Queries.ViewModels;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Products.Queries.GetAllProducts;

public record GetAllProductsQuery() : IRequest<ErrorOr<ListProductsVm>>;


