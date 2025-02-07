using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Contract.Event
{
    public class OrderApprovedEvent:DomainEvent
    {
        public Guid OrderId { get; set; }
    }
}
