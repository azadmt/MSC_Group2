using Framework.Domain;

namespace ProductCatalog.Domain.Product
{
    public class ProductCode: ValueObject
    {
        public string Value { get; private set; }

        public static ProductCode CreatePrductCode(CountryCode countryCode, int sequence)
        {
            var pc = new ProductCode( countryCode,  sequence);
            //pc.Value = $"{countryCode.ToString()}{sequence.ToString().PadLeft(7, '0')}";
            return pc;
        }

        protected override IEnumerable<object> GetEqualityAttribute()
        {
            yield return Value;
        }

        private ProductCode(CountryCode countryCode, int sequence)
        {
            Value = $"{countryCode.Value}{sequence.ToString().PadLeft(7, '0')}";
        }

        private  ProductCode()
        {

        }
    }
}
