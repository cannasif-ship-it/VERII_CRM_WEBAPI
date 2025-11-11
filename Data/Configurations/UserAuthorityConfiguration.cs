using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using cms_webapi.Models;

namespace cms_webapi.Data.Configurations
{
    public class UserAuthorityConfiguration : IEntityTypeConfiguration<UserAuthority>
    {
        public void Configure(EntityTypeBuilder<UserAuthority> builder)
        {
            // Table name
            builder.ToTable("RII_USER_AUTHORITY");

            // Primary key
            builder.HasKey(e => e.Id);

            // Base properties
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.CreatedDate)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            // Specific properties
            builder.Property(e => e.Title)
                .HasMaxLength(30)
                .IsRequired();

            // Indexes
            builder.HasIndex(e => e.Title)
                .IsUnique();

            // Soft delete filter
            builder.HasQueryFilter(e => !e.IsDeleted);

            // Seed deterministic roles
            builder.HasData(
                new UserAuthority { Id = 1, Title = "User", CreatedDate = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false },
                new UserAuthority { Id = 2, Title = "Manager", CreatedDate = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false },
                new UserAuthority { Id = 3, Title = "Admin", CreatedDate = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc), IsDeleted = false }
            );
        }
    }
}