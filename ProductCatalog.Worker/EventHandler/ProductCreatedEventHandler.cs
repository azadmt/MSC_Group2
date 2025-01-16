using MassTransit;
using ProductCatalog.DomainContract.Event.Product;
using ProductCatalog.Query.DAL;
using ProductCatalog.Query.DAL.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Worker.EventHandler
{
    internal class ProductCreatedEventHandler : IConsumer<ProductCreatedEvent>
    {
        QueryDbContext dbContext;

        public ProductCreatedEventHandler(QueryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async  Task Consume(ConsumeContext<ProductCreatedEvent> context)
        {
            var pEvent = context.Message;
            var product = new Product
            {
                Id = pEvent.ProductId,
                Code = pEvent.Code,
                Name = pEvent.Name,
                Color_B = pEvent.Color_B,
                Color_G = pEvent.Color_G,
                Color_R = pEvent.Color_R,
                CountryCode = pEvent.CountryCode,
                Price = pEvent.Price

            };

            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
        }
    }
}
