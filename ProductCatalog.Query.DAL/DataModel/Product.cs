using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Query.DAL.DataModel
{
    public class Product
    {
        public Guid Id { get;  set; }
        public string Name { get;  set; }
        public string Code { get;  set; }
        public string CountryCode { get;  set; }
        public decimal Price { get;  set; }
        public byte Color_R { get;  set; }
        public byte Color_B { get;  set; }
        public byte Color_G { get;  set; }
    }
}
