using Framework.Domain;

namespace ProductCatalog.Domain.Product
{
    public class Color : ValueObject
    {
        public byte Red { get; private set; }

        public byte Green { get; private set; }
        public byte Blue { get; private set; }

        public Color(byte red, byte green, byte blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        protected override IEnumerable<object> GetEqualityAttribute()
        {
            return new object[] { Red, Green, Blue };
        }
    }
}
