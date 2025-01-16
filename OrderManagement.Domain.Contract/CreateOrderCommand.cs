using Framework.Application;

namespace OrderManagement.Domain.Contract
{
    public class CreateOrderCommand : ICommand
    {
        public Guid CustomerId { get; set; }

        public List<OrderItemDto> OrderItems { get; set; }
    }

    public class OrderItemDto
    {
        public Guid ProductId { get;  set; }
        public uint Quantity { get;  set; }
        public decimal UnitPrice { get;  set; }
    }
}