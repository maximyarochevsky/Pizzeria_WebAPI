using Microsoft.EntityFrameworkCore;
using Pizzeria.Infrastructure.Persistence.Configurations;

namespace Pizzeria.Infrastructure.Persistence;

public class PizzeriaDbContext : DbContext
{
   
    public PizzeriaDbContext(DbContextOptions<PizzeriaDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new OrderConfiguration());
        builder.ApplyConfiguration(new OrderItemConfiguration());
        builder.ApplyConfiguration(new ProductConfiguration());
        builder.ApplyConfiguration(new SectionConfiguration());
        base.OnModelCreating(builder);
    }
}
