using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductPriceTracking.Dal.Concrete.EntityFrameworkCore.Mapping.ExtensionMethods;
using ProductPriceTracking.Entities.Concrete;

namespace ProductPriceTracking.Dal.Concrete.EntityFrameworkCore.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.EntityBaseMap();
            builder.EntityUniqueString(x => x.Url, 300);
            builder.Property(x => x.Name).IsRequired();

            builder.HasMany(x => x.TrackingRecords)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
