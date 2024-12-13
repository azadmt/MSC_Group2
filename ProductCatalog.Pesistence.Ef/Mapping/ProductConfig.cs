using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Domain.Product;

namespace ProductCatalog.Pesistence.Ef.Mapping
{
    public class ProductConfig : IEntityTypeConfiguration<ProductAggregate>
    {
        public void Configure(EntityTypeBuilder<ProductAggregate> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne<Money>(x => x.Price);
            builder.OwnsOne<Color>(x => x.Color);
            builder.OwnsOne<ProductCode>(x => x.Code);
            builder.OwnsOne<CountryCode>(x => x.CountryCode);
            builder.Property(x => x.Name).HasMaxLength(50);

        }
    }
}
