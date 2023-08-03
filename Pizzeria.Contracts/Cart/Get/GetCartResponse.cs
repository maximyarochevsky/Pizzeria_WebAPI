using Pizzeria.Domain.Entities;

namespace Pizzeria.Contracts.Cart.Get;

public class GetCartResponse
{
    public List<CartItem>? Items { get; set; }
    public string ItemsCount => Items.Sum(item => item.Quantity).ToString();
    public string TotalPrice { get; set; }
}
