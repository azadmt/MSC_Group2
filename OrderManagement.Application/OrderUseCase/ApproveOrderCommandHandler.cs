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
    public class ApproveOrderCommandHandler : ICommandHandler<ApproveOrderCommand>
    {
        private IOrderRepository orderRepository;

        public ApproveOrderCommandHandler(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public void Handle(ApproveOrderCommand command)
        {
            var order=orderRepository.Get(command.OrderId);
            order.Approve();
            orderRepository.Update(order);
        }
    }
}
