using Framework.Application;
using OrderManagement.Domain.Contract;
using OrderManagement.Domain.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.OrderUseCase
{
    public class CreateOrderCommandHamdler :
        ICommandHandler<CreateOrderCommand>
    {
        IOrderRepository orderRepository;

        public CreateOrderCommandHamdler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public void Handle(CreateOrderCommand command)
        {
            var orderNo = new Random().Next(0, 100);
            var order=OrderAggregate.Create(command, orderNo);
            
            
            orderRepository.Save(order);
            //Adjust inventory
        }

        public void Handle(ApproveOrderCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
