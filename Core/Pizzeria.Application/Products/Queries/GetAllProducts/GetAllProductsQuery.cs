using MediatR;
using Pizzeria.Application.Products.Queries.ViewModels;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Products.Queries.GetAllProducts;

public class GetAllProductsQuery : IRequest<ListProductsVm>
{
}

