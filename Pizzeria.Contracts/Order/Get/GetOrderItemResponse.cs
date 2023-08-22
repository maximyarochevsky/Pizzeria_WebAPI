
using Pizzeria.Contracts.Product.Get;

namespace Pizzeria.Contracts.Order.Get;

public record GetOrderItemResponse(
    decimal Price,
    int Quantity,
    GetProductDetailsResponse Product);   


