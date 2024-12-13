using Framework.Application;
using ProductCatalog.Domain.Product;
using ProductCatalog.DomainContract;
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

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
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
        }
    }
}
