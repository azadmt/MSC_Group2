using Framework.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application;
using ProductCatalog.DomainContract;

namespace ProductCatalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ICommandBus commandBus;

        public ProductController(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
        }



        [HttpPost]
        public IActionResult CreteProduct(CreateProductCommand command)
        {
            //productService.CreateProduct(productDto);
            commandBus.Send(command);
            return Ok();
        }
    }
}
