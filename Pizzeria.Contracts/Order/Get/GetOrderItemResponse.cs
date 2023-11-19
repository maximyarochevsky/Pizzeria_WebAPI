
using Pizzeria.Contracts.Product.Get;

namespace Pizzeria.Contracts.Order.Get;

public class GetOrderItemResponse
{
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public GetProductDetailsResponse Product { get; set; }
}

 


