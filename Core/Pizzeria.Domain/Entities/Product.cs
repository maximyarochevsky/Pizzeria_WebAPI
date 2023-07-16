using Pizzeria.Domain.Entities.Base;

namespace Pizzeria.Domain.Entities;

public class Product:Entity
{
    public decimal Price { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Order>? Orders { get; set; }
    public Section Section { get; set; }
}