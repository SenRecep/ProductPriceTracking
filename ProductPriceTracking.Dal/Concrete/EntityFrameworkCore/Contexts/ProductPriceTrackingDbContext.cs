using Microsoft.EntityFrameworkCore;
using ProductPriceTracking.Dal.Concrete.EntityFrameworkCore.Mapping;
using ProductPriceTracking.Entities.Concrete;

namespace ProductPriceTracking.Dal.Concrete.EntityFrameworkCore.Contexts
{
    public class ProductPriceTrackingDbContext : DbContext
    {
        public ProductPriceTrackingDbContext(DbContextOptions<ProductPriceTrackingDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WebsiteMap());
            modelBuilder.ApplyConfiguration(new PricePositionMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new TrackingRecordMap());
            modelBuilder.ApplyConfiguration(new AppRoleMap());
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new UserRoleMap());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Website> Websites { get; set; }
        public DbSet<PricePosition> PricePositions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<TrackingRecord> TrackingRecords { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
