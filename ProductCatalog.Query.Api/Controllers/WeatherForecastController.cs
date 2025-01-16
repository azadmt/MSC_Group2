using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Query.DAL;
using ProductCatalog.Query.DAL.DataModel;

namespace ProductCatalog.Query.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        QueryDbContext dbContext;

        public ProductController(QueryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        [HttpGet()]
        public IEnumerable<Product> Get()
        {
            return dbContext.Products.ToList();
            
        }
    }
}