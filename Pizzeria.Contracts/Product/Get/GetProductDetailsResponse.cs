using Pizzeria.Application.Common.Mappings;

namespace Pizzeria.Contracts.Product.Get;

public class GetProductDetailsResponse
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Price { get; set; }
    public string Section { get; set; }
}

    


