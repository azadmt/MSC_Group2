using Framework.Domain;
using OrderManagement.Domain.Contract;
using OrderManagement.Domain.Contract.Event;
using OrderManagement.Domain.Order.State;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Order
{
    public class OrderAggregate : AggregateRoot<Guid>
    {
        public static OrderAggregate Create(CreateOrderCommand createOrderCommand, int ordernumber)
        {

            var ag = new OrderAggregate();

            ag.Id = Guid.NewGuid();
            ag.OrderDate = DateTime.Now;
            ag.OrderNumber = ordernumber;
            ag.CustomerId = createOrderCommand.CustomerId;
            ag.State = new PendingState();
            if (!createOrderCommand.OrderItems.Any())
            {
                throw new CanNotCreateOrderWithoutOrderItemsException();
            }
            foreach (var item in createOrderCommand.OrderItems)
            {
                ag._orderItems.Add(new OrderItem(Guid.NewGuid(),
                    item.ProductId,
                    new Quantity(item.Quantity),
                    new Money(item.UnitPrice)));
            }
            ag.AddChanges(new OrderCreatedEvent(ag.Id,
                ag.OrderDate,
                ag.OrderItems
                .Select(x => new OrderItemDto() { ProductId = x.ProductId, Quantity = x.Quantity, UnitPrice = x.UnitPrice.Value })
                .ToList()));
            return ag;
        }
        public int OrderNumber { get; private set; }

        public decimal Total { get; private set; }

        public Guid CustomerId { get; private set; }
        public DateTime OrderDate { get; private set; }
        public OrderState State { get; private set; }

        protected List<OrderItem> _orderItems = new();
        public IEnumerable<OrderItem> OrderItems => _orderItems.AsReadOnly();


        public void Approve()
        {
            //if (State != OrderState.New)
            //    throw new InvalidOperationException();

            State = new ApprovedState();
            AddChanges(new OrderApprovedEvent { OrderId = Id });

        }


        public void Cancle()
        {
            //if (State != OrderState.Approved || State != OrderState.New)
            //    throw new InvalidOperationException();

            State = new CancledState();
        }

        public void Deliver()
        {
            State = new DeliveredState();

        }
    }
}
