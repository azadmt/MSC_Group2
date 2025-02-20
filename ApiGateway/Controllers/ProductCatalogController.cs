using ApiGateway.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.DomainContract;

namespace ApiGateway.Controllers
{
    [Route("api/ProductCatalog/[controller]")]
    [ApiController]
    public class ProductCatalogController : ControllerBase
    {
        string ServiceName = "ProductCatalog";
        public ProductCatalogController()
        {

        }
        [HttpPost]
        public IActionResult CreteProduct(CreateProductCommand command)
        {
            var serviceUrl = ServiceDiscovery.GetServcice(ServiceName);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(serviceUrl);
            client.PostAsJsonAsync("Product", command);
            return Ok();
        }
    }
}
