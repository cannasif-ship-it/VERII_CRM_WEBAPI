using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using cms_webapi.Models;

namespace cms_webapi.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // Table name
            builder.ToTable("RII_CUSTOMER");

            // Basic Information
            builder.Property(e => e.CustomerCode)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(e => e.CustomerName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(e => e.CustomerTypeId)
                .IsRequired(false);

            // Tax Information
            builder.Property(e => e.TaxOffice)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(e => e.TaxNumber)
                .HasMaxLength(50)
                .IsRequired(false);

            // Classification
            builder.Property(e => e.SalesRepCode)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(e => e.GroupCode)
                .HasMaxLength(50)
                .IsRequired(false);

            // Financial Information
            builder.Property(e => e.CreditLimit)
                .HasColumnType("decimal(18,2)")
                .IsRequired(false);

            // ERP Integration
            builder.Property(e => e.BranchCode)
                .IsRequired();

            builder.Property(e => e.BusinessUnitCode)
                .IsRequired();

            // Contact Information
            builder.Property(e => e.Notes)
                .HasMaxLength(1000)
                .IsRequired(false);

            builder.Property(e => e.Email)
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(e => e.Website)
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(e => e.Phone1)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(e => e.Phone2)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(e => e.Address)
                .HasMaxLength(500)
                .IsRequired(false);

            // Location Information
            builder.Property(e => e.CountryId)
                .IsRequired(false);

            builder.Property(e => e.CityId)
                .IsRequired(false);

            builder.Property(e => e.DistrictId)
                .IsRequired(false);

            // Foreign Key Relationships
            builder.HasOne(e => e.Countries)
                .WithMany()
                .HasForeignKey(e => e.CountryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.Cities)
                .WithMany()
                .HasForeignKey(e => e.CityId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.Districts)
                .WithMany()
                .HasForeignKey(e => e.DistrictId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.CustomerTypes)
                .WithMany(ct => ct.Customers)
                .HasForeignKey(e => e.CustomerTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            // Indexes
            builder.HasIndex(e => e.CustomerCode)
                .IsUnique()
                .HasFilter("[CustomerCode] IS NOT NULL");

            builder.HasIndex(e => e.TaxNumber)
                .HasFilter("[TaxNumber] IS NOT NULL");

            builder.HasIndex(e => e.Email)
                .HasFilter("[Email] IS NOT NULL");
        }
    }
}
