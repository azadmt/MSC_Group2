using Framework.Domain;
using System.Text.Json.Serialization;

namespace OrderManagement.Domain.Contract.Event
{
    public class OrderCreatedEvent : DomainEvent
    {
        public OrderCreatedEvent(Guid orderId,DateTime orderDate,List<OrderItemDto> orderItemDtos)
        {
            OrderId = orderId;
            OrderDate = orderDate;
            Items = orderItemDtos;
        }

        [JsonConstructor]
        public OrderCreatedEvent()
        {

        }

        [JsonInclude]
        public Guid OrderId { get; private set; }

        [JsonInclude]
        public DateTime OrderDate{ get;private set; }

        [JsonInclude]
        public List<OrderItemDto> Items { get; private set; }
    }
}
