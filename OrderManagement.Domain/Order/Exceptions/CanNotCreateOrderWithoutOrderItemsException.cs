using Framework.Domain;
using System.Runtime.Serialization;

namespace OrderManagement.Domain.Order
{
    [Serializable]
    internal class CanNotCreateOrderWithoutOrderItemsException : DomainException
    {
        public CanNotCreateOrderWithoutOrderItemsException()
        {
        }

     
    }
}