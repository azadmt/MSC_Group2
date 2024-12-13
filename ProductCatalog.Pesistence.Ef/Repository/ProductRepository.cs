using ProductCatalog.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Pesistence.Ef.Repository
{
    public class ProductRepository : IProductRepository
    {
        ProductCatalogDbContext _dbContext;
        public ProductRepository(ProductCatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ProductAggregate Get(Guid id)
        {
          return _dbContext.Set<ProductAggregate>().Single(x=>x.Id==id);
        }

        public void Save(ProductAggregate product)
        {
            _dbContext.Set<ProductAggregate>().Add(product);
            _dbContext.SaveChanges();
        }

        public void Update(ProductAggregate product)
        {
            _dbContext.Set<ProductAggregate>().Update(product);
            _dbContext.SaveChanges();
        }
    }
}
