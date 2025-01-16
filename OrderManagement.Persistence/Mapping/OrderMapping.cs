using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagement.Domain.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Persistence.Mapping
{
    internal class OrderMapping : IEntityTypeConfiguration<OrderAggregate>
    {
        public void Configure(EntityTypeBuilder<OrderAggregate> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CustomerId);
            builder.Property(x => x.OrderDate);
            builder.Property(x => x.OrderNumber);

            builder.OwnsMany(x => x.OrderItems, b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.ProductId);
                b.OwnsOne(x => x.Quantity);
                b.OwnsOne(x => x.UnitPrice);
            });
            builder
                .Metadata
                .FindNavigation(nameof(OrderAggregate.OrderItems))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
