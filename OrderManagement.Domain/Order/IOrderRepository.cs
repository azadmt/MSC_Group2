using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Order
{
    public interface IOrderRepository
    {
        OrderAggregate Get(Guid id);
        void Save(OrderAggregate orderAggregate);
        void Update(OrderAggregate orderAggregate);
    }
}
