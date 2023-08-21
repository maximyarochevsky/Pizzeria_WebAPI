using Microsoft.EntityFrameworkCore;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Application.Interfaces;

public interface IPizzeriaDbContext
{
   DbSet<Section> Sections { get; set; }
   DbSet<Product> Products { get; set; }
   DbSet<OrderItem> OrderItems { get; set; }
   DbSet<Order> Orders { get; set; }
   DbSet<User> Users { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
