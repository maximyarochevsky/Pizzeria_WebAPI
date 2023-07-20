using Pizzeria.Domain.Entities.Base;

namespace Pizzeria.Domain.Entities;

public class OrderItem:Entity
{
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public Product Product { get; set; }
    public Order Order { get; set; }
}