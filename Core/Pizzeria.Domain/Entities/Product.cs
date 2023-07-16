using Pizzeria.Domain.Entities.Base;

namespace Pizzeria.Domain.Entities;

public class Product:Entity
{
    public decimal Price { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
    public Section SectionId { get; set; }
}