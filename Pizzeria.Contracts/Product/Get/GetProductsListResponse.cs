namespace Pizzeria.Contracts.Product.Get;

public record GetProductsListResponse
{ 
  public List<GetProductDetailsResponse> Products { get; set; }
}