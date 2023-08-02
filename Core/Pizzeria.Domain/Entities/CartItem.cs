namespace Pizzeria.Domain.Entities;

public class CartItem
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}

