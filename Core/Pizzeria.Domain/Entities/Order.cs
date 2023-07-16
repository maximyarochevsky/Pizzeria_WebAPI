using Pizzeria.Domain.Entities.Base;

namespace Pizzeria.Domain.Entities;

public class Order: Entity
{
    public decimal TotalPrice { get; set; }
    public string? Description { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;
    public ICollection<OrderItem>? Items { get; set; }
}

