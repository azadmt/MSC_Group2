using Framework.Domain;

namespace OrderManagement.Domain.Order
{
    public class Quantity : ValueObject
    {
        public uint Value { get; private set; }

        private Quantity() { }
        public Quantity(uint value)
        {
            Value = value;
        }
        protected override IEnumerable<object> GetEqualityAttribute()
        {
            yield return Value;
        }

        public static implicit operator uint(Quantity money)
        {
            return money.Value;
        }

        public static implicit operator Quantity(uint value)
        {
            return new Quantity(value);

        }
    }
}
