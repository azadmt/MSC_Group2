using OrderManagement.Domain.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Persistence.Repository
{
    public class OrderRepository : IOrderRepository
    {
        OrderManagementDbContext _dbContext;

        public OrderRepository(OrderManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public OrderAggregate Get(Guid id)
        {
            return _dbContext.Set<OrderAggregate>().Single(x=> x.Id==id);
        }

        public void Save(OrderAggregate orderAggregate)
        {
            _dbContext.Set<OrderAggregate>().Add(orderAggregate);
            _dbContext.SaveChanges();
        }

        public void Update(OrderAggregate orderAggregate)
        {
            _dbContext.Set<OrderAggregate>().Update(orderAggregate);
            _dbContext.SaveChanges();
        }
    }
}
