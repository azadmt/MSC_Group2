using Framework.Application;
using InventoryManagement.Contract;
using MassTransit;
using OrderManagement.Domain.Contract;

namespace OrderManagement.Api.EventHandler
{
    public class StockAdjusmentConfirmedEventHandler : IConsumer<StockAdjusmentConfirmedEvent>
    {
        ICommandBus commandBus;

        public StockAdjusmentConfirmedEventHandler(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
        }

        public async Task Consume(ConsumeContext<StockAdjusmentConfirmedEvent> context)
        {
            commandBus.Send(new ApproveOrderCommand { OrderId=context.Message.OrderId});
        }
    }
}
