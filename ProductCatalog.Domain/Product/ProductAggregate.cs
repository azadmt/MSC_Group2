using Framework.Domain;
using ProductCatalog.DomainContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Domain.Product
{
    public class ProductAggregate: Entity<Guid>
    {
        private ProductAggregate()
        {

        }
        //public static ProductAggregate CreateProduct(
        //    Guid id,
        //    string name,
        //    decimal price,
        //    string countryCode,
        //    byte color_r,
        //    byte color_g,
        //    byte color_b,
        //    int sequence
        //    )
        //{
        //    var cCode = new CountryCode(countryCode);
        //   return new ProductAggregate(id,
        //        name, 
        //        new Color(color_r, color_g, color_b),
        //        new Money(price),
        //        ProductCode.CreatePrductCode(cCode, sequence),
        //        cCode
        //        );    


        //}
        public static ProductAggregate CreateProduct(
           Guid id,
        CreateProductCommand createProductCommand,
           int sequence
           )
        {
            var cCode = new CountryCode(createProductCommand.CountryCode);
            return new ProductAggregate(id,
                 createProductCommand.Name,
                 new Color(createProductCommand.Color_R, createProductCommand.Color_G, createProductCommand.Color_B),
                 new Money(createProductCommand.Price),
                 ProductCode.CreatePrductCode(cCode, sequence),
                 cCode
                 );


        }



        public ProductAggregate(Guid id, string name, Color color, Money price, ProductCode code, CountryCode countryCode)
        {
            Id = id;
            Name = name;
            Color = color;
            Price = price;
            Code = code;
            CountryCode = countryCode;
        }

        public string Name { get; private set; }
        public Color Color { get; private set; }
        public Money Price{ get; private set; }
        public ProductCode Code { get; private set; }
        public CountryCode CountryCode { get; private set; }
    }
}
