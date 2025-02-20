using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagement.Domain.Order;
using OrderManagement.Domain.Order.State;
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
            builder.Property(x => x.Total);
            builder.Property(x => x.RowVersion).IsRowVersion().IsConcurrencyToken();
            builder.Property(x => x.State)
                .HasConversion(
                p=> p.GetType().Name,
                p=> GetOrderState(p)
                );

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
        public OrderState GetOrderState(string state)
        {
            return state switch
            {
                nameof(PendingState) => new PendingState(),
                nameof(CancledState) => new CancledState(),
                nameof(ApprovedState) => new ApprovedState(),
                nameof(DeliveredState) => new DeliveredState(),
                _ => new PendingState(),
            };
        }
    }
}
