using MassTransit;
using ProductCatalog.DomainContract.Event.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Worker.EventHandler
{
    internal class ProductCreatedEventHandler : IConsumer<ProductCreatedEvent>
    {
        public Task Consume(ConsumeContext<ProductCreatedEvent> context)
        {
            throw new NotImplementedException();
        }
    }
}
