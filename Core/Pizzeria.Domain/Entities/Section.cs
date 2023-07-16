using Pizzeria.Domain.Entities.Base;

namespace Pizzeria.Domain.Entities;

public class Section: Entity
{
    public ICollection<Product> Products { get; set; }
    public string Name { get; set; }
}