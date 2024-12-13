using Framework.Domain;

namespace ProductCatalog.Domain.Product
{
    public class Money : ValueObject
    {
        public decimal Value { get; private set; }

        public Money(decimal value)
        {
            if (value < 0)
            {
                throw new Exception("value can not be  lowerthan 0");
            }
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityAttribute()
        {
            return new object[] { Value };
        }
    }
}
