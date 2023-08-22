namespace Pizzeria.Contracts.Product.Get;

public record GetProductsListResponse(List<GetProductDetailsResponse> Products);
