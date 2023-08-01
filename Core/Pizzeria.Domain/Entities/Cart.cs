namespace Pizzeria.Domain.Entities;

public class Cart
{
    public List<CartItem>? Items { get; set; }
    public int ItemsCount => Items.Sum(item => item.Quantity);
    public decimal TotalPrice { get; set; }
}