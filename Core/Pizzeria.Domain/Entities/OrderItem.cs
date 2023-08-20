using Pizzeria.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizzeria.Domain.Entities;

public class OrderItem:Entity
{
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public Product Product { get; set; }
    public Order Order { get; set; }
    public Guid OrderId { get; set; }
}