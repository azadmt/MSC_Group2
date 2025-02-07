using Framework.Application;
using System.Text.Json.Serialization;

namespace OrderManagement.Domain.Contract
{

    public class CreateOrderCommand : ICommand
    {
        public Guid CustomerId { get; set; }

        public List<OrderItemDto> OrderItems { get; set; }
    }

    public class OrderItemDto
    {
        [JsonInclude]
        public Guid ProductId { get;  set; }
        [JsonInclude]
        public uint Quantity { get;  set; }
        [JsonInclude]
        public decimal UnitPrice { get;  set; }
    }
}