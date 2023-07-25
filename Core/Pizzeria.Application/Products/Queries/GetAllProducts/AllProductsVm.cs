using Pizzeria.Application.Common.Mappings;
using Pizzeria.Application.Products.Queries.GetProductDetails;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Products.Queries.GetAllProducts;

public class AllProductsVm 
{
    public IList<ProductDetailsVm> AllProducts { get; set; }
}

