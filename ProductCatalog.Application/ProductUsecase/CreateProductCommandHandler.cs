using Framework.Application;
using MassTransit;
using ProductCatalog.Domain.Product;
using ProductCatalog.DomainContract;
using ProductCatalog.DomainContract.Event.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Application.ProductUsecase
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
    {
        IProductRepository productRepository;
        IBusControl busControl;
        public CreateProductCommandHandler(IProductRepository productRepository, IBusControl busControl)
        {
            this.productRepository = productRepository;
            this.busControl = busControl;
        }

        public void Handle(CreateProductCommand command)
        {
            var sequence = 1;//get new sequence
            var product = ProductAggregate.CreateProduct(
                Guid.NewGuid(),
               command,
                sequence
                );
         
            productRepository.Save(product);

            foreach (var domainEvent in product.GetChanges())
            {
                busControl.Publish(domainEvent as ProductCreatedEvent).GetAwaiter().GetResult();
            } 
        }
    }
}
