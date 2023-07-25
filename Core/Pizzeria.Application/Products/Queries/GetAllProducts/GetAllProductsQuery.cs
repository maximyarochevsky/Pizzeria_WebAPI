using MediatR;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Products.Queries.GetAllProducts;

public class GetAllProductsQuery : IRequest<Product>
{

}

