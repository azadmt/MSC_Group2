using Framework.Application;

namespace OrderManagement.Domain.Contract
{
    public class ApproveOrderCommand : ICommand
    {
        public Guid OrderId { get; set; }
    }
}