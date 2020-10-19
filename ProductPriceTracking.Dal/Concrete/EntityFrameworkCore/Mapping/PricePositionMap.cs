using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductPriceTracking.Dal.Concrete.EntityFrameworkCore.Mapping.ExtensionMethods;
using ProductPriceTracking.Entities.Concrete;

namespace ProductPriceTracking.Dal.Concrete.EntityFrameworkCore.Mapping
{
    public class PricePositionMap : IEntityTypeConfiguration<PricePosition>
    {
        public void Configure(EntityTypeBuilder<PricePosition> builder)
        {
            builder.EntityBaseMap();
            builder.Property(x => x.Priority).IsRequired();
            builder.Property(x => x.XPath).IsRequired();

        }
    }
}
