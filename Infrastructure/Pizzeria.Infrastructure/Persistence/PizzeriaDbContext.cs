using Microsoft.EntityFrameworkCore;
using Pizzeria.Application.Interfaces;
using Pizzeria.Domain.Entities;
using Pizzeria.Infrastructure.Persistence.Configurations;

namespace Pizzeria.Infrastructure.Persistence;

public class PizzeriaDbContext : DbContext, IPizzeriaDbContext
{
    public DbSet<Section> Sections { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Order>  Orders { get; set; }
    public DbSet<User>  Users { get; set; }

    public PizzeriaDbContext(DbContextOptions<PizzeriaDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new OrderConfiguration());
        builder.ApplyConfiguration(new OrderItemConfiguration());
        builder.ApplyConfiguration(new ProductConfiguration());
        builder.ApplyConfiguration(new SectionConfiguration());
        builder.ApplyConfiguration(new UserConfiguration());
        base.OnModelCreating(builder);
    }
}
