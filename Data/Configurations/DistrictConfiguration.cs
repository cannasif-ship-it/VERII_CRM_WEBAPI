using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using cms_webapi.Models;

namespace cms_webapi.Data.Configurations
{
    public class DistrictConfiguration : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            // Table name
            builder.ToTable("RII_DISTRICT");

            // Properties
            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.ERPCode)
                .HasMaxLength(10)
                .IsRequired(false);

            builder.Property(e => e.CityId)
                .IsRequired();

            // Foreign Key Relationships
            builder.HasOne(e => e.City)
                .WithMany(c => c.Districts)
                .HasForeignKey(e => e.CityId)
                .OnDelete(DeleteBehavior.NoAction);

            // Indexes
            builder.HasIndex(e => e.Name);

            builder.HasIndex(e => e.ERPCode)
                .IsUnique()
                .HasFilter("[ERPCode] IS NOT NULL");

            builder.HasIndex(e => e.CityId);
        }
    }
}
