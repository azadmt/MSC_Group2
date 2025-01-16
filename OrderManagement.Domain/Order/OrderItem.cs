using Framework.Domain;

namespace OrderManagement.Domain.Order
{
    public class OrderItem : Entity<Guid>
    {

        public Guid ProductId { get; private set; }

        private OrderItem() { }
        public OrderItem(Guid id, Guid productId, Quantity quantity, Money unitPrice):base(id)
        {
            ProductId = productId;
            Quantity = quantity;
            UnitPrice= unitPrice;

        }

        public Quantity Quantity { get; private set; }
        public Money UnitPrice { get; private set; }
    }
}
