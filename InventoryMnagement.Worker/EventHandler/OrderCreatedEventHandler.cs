using InventoryManagement.Contract;
using InventoryMnagement.Worker.DataAccess;
using MassTransit;
using OrderManagement.Domain.Contract.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMnagement.Worker.EventHandler
{
    internal class OrderCreatedEventHandler : IConsumer<OrderCreatedEvent>
    {
        InventoryManagementDbContext dbContext;

        public OrderCreatedEventHandler(InventoryManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            //TODO implement InboxPattern
            var orderEvent = context.Message;
            var productsId= orderEvent.Items.Select(x => x.ProductId).ToList();
            var stocks = dbContext.stocks.Where(x => productsId.Contains(x.ProductId)).ToList();
            foreach (var item in stocks)
            {
                var orderLine=  orderEvent.Items.FirstOrDefault(x => x.ProductId == item.ProductId);
                if(item.Quantity<orderLine.Quantity)
                {
                    await context.Publish(new StockAdjusmentRejectedEvent() { OrderId=orderEvent.Id});
                    return;
                }
                else
                {
                    item.Quantity-=orderLine.Quantity;
                }
            }
            dbContext.stocks.UpdateRange(stocks);
            dbContext.SaveChanges();
            await context.Publish(new StockAdjusmentConfirmedEvent() { OrderId = orderEvent.Id });

        }
    }
}
