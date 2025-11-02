using Microsoft.EntityFrameworkCore;
using cms_webapi.Models;
using cms_webapi.Data.Configurations;

namespace cms_webapi.Data
{
    public class CmsDbContext : DbContext
    {
        public CmsDbContext(DbContextOptions<CmsDbContext> options) : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ProductPricing> ProductPricings { get; set; }
        public DbSet<ProductPricingGroupBy> ProductPricingGroupBys { get; set; }
        public DbSet<UserDiscountLimit> UserDiscountLimits { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<ShippingAddress> ShippingAddresses { get; set; }
        public DbSet<Quotation> Quotations { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply all configurations from the Configurations folder
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CmsDbContext).Assembly);
        }
    }
}
