using Framework.Domain;

namespace ProductCatalog.Domain.Product
{
    public class CountryCode:ValueObject
    {
        
        public string Value { get; private set; }

        public CountryCode(string value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            if (!value.StartsWith("1"))
                throw new ArgumentException("value must start with 1");

            if (value.Length != 3)
                throw new ArgumentException("value lenght must be 3");
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityAttribute()
        {
           yield return Value;
        }
    }
}
