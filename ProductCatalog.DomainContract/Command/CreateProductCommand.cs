using Framework.Application;

namespace ProductCatalog.DomainContract
{

    public class CreateProductCommand : ICommand
    {
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public decimal Price { get; set; }
        public byte Color_R { get; set; }
        public byte Color_B { get; set; }
        public byte Color_G { get; set; }
    }
    //public class ProductDto
    //{
    //    public string Name { get; set; }
    //    public string CountryCode { get; set; }
    //    public decimal Price { get; set; }
    //    public byte Color_R { get; set; }
    //    public byte Color_B { get; set; }
    //    public byte Color_G { get; set; }
    //}
}