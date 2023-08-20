using Pizzeria.Domain.Entities.Base;

namespace Pizzeria.Domain.Entities;

public class Order: Entity
{
    public decimal TotalPrice { get; set; }
    public string? Description { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public DateTime Date { get; set; } 
    public List<OrderItem> OrderItems { get; set; }
}

