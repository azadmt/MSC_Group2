using ApiGateway.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRegistryController : ControllerBase
    {

        [HttpPost]
        public IActionResult Register(ServiceDefiniton serviceDefinition)
        {
            ServiceRegistry.Register(serviceDefinition);
            return Ok();
        }
    }
}
