using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProductPriceTracking.Dal.Concrete.EntityFrameworkCore.Mapping.ExtensionMethods;
using ProductPriceTracking.Entities.Concrete;

namespace ProductPriceTracking.Dal.Concrete.EntityFrameworkCore.Mapping
{
    public class WebsiteMap : IEntityTypeConfiguration<Website>
    {
        public void Configure(EntityTypeBuilder<Website> builder)
        {
            builder.EntityBaseMap();

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.IconName).IsRequired();
            builder.EntityUniqueString(x => x.BaseUrl, 150);

            builder.HasMany(x => x.PricePositions)
                .WithOne(x => x.Website)
                .HasForeignKey(x => x.WebsiteId)
                .OnDelete( DeleteBehavior.Cascade);

            builder.HasMany(x => x.Products)
               .WithOne(x => x.Website)
               .HasForeignKey(x => x.WebsiteId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.TrackingRecords)
               .WithOne(x => x.Website)
               .HasForeignKey(x => x.WebsiteId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
