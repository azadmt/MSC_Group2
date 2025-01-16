using Framework.Application;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Domain.Contract;

namespace OrderManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {

        private readonly ICommandBus commandBus;
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger, ICommandBus commandBus)
        {
            _logger = logger;
            this.commandBus = commandBus;
        }

        [HttpPost]
        public IActionResult Post(CreateOrderCommand createOrderCommand)
        {
            commandBus.Send(createOrderCommand);
            return Ok();
        }
    }
}