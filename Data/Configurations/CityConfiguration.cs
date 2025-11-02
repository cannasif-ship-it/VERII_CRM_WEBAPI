using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using cms_webapi.Models;

namespace cms_webapi.Data.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            // Table name
            builder.ToTable("RII_CITY");

            // Properties
            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.ERPCode)
                .HasMaxLength(10)
                .IsRequired(false);

            builder.Property(e => e.CountryId)
                .IsRequired();



            // Indexes
            builder.HasIndex(e => e.Name);

            builder.HasIndex(e => e.CountryId);
        }
    }
}
