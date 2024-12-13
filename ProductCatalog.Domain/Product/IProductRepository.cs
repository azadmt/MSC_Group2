using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Domain.Product
{
    public interface IProductRepository
    {
        public ProductAggregate Get(Guid id);
        public void Save(ProductAggregate product);
        public void Update(ProductAggregate product);


    }
}
