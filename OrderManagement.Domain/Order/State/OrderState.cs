using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Order.State
{
    public abstract  class OrderState
    {

        public virtual OrderState Pending() => throw new NotImplementedException();
        public virtual OrderState Approved() => throw new NotImplementedException();
        public virtual OrderState Canceled() => throw new NotImplementedException();
        public virtual OrderState Delivered() => throw new NotImplementedException();
        public virtual OrderState Shiped() => throw new NotImplementedException();
    }


    public class PendingState : OrderState
    {
        public override OrderState Canceled()
        {
            return new CancledState();
        }

        public override OrderState Approved()
        {
            return new ApprovedState();
        }
    }


    public class ApprovedState : OrderState
    {
        public override OrderState Canceled()
        {
            return new CancledState();
        }

        public override OrderState Shiped()
        {
            return new ShipedState();
        }
    }

    public class CancledState : OrderState
    {

    }

    public class DeliveredState : OrderState
    {

    }
    public class ShipedState : OrderState
    {
        public override OrderState Delivered()
        {
            return new DeliveredState();
        }
    }
}
