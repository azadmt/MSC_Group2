using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.DomainContract.Event.Product
{
    public class ProductCreatedEvent : DomainEvent
    {

        public ProductCreatedEvent(Guid productId, string name,string code, string countryCode, decimal price, byte color_R, byte color_B, byte color_G)
        {
            ProductId = productId;
            Name = name;
            Code = code;    
            CountryCode = countryCode;
            Price = price;
            Color_R = color_R;
            Color_B = color_B;
            Color_G = color_G;
        }

        public Guid ProductId { get; private set; }
        public string Name { get; private set; }
        public string Code { get; private set; }
        public string CountryCode { get; private set; }
        public decimal Price { get; private set; }
        public byte Color_R { get; private set; }
        public byte Color_B { get; private set; }
        public byte Color_G { get; private set; }
    }
}
