using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzeria.Domain.Entities;

namespace Pizzeria.Infrastructure.Persistence.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(order => order.Id);
        builder.Property(order => order.TotalPrice)
            .HasColumnType("decimal(18,2)");
        builder.Property(order => order.Description);
        builder.Property(order => order.Address);
        builder.Property(order => order.Date);
        builder.Property(order => order.Phone);
        builder.Property(order => order.Id);
        builder.HasMany(order => order.Items);
    }
}