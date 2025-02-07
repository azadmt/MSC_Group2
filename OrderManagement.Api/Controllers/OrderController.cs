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

        [HttpPost(nameof(CreateOrder))]
        public IActionResult CreateOrder(CreateOrderCommand createOrderCommand)
        {
            commandBus.Send(createOrderCommand);
            return Ok();
        }

        [HttpPost(nameof(ApproveOrder))]
        public IActionResult ApproveOrder(ApproveOrderCommand command)
        {
            commandBus.Send(command);
            return Ok();
        }
    }
}