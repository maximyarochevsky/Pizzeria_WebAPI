using Pizzeria.Application.Common.Mappings;

namespace Pizzeria.Contracts.Product.Get;

public record GetProductDetailsResponse(
    string Name,
    string Description,
    string Price,
    string Section);

    


