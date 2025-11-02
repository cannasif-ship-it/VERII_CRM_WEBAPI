using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using cms_webapi.Models;

namespace cms_webapi.Data.Configurations
{
    public class UserConfiguration : BaseEntityConfiguration<User>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<User> builder)
        {
            // Table name
            builder.ToTable("Users");

            // Properties configuration
            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.PasswordHash)
                .IsRequired();

            builder.Property(u => u.PhoneNumber)
                .HasMaxLength(20);

            builder.Property(u => u.Role)
                .HasMaxLength(50)
                .HasDefaultValue("User");

            builder.Property(u => u.IsActive)
                .HasDefaultValue(true);

            builder.Property(u => u.IsEmailConfirmed)
                .HasDefaultValue(false);

            // Indexes
            builder.HasIndex(u => u.Email)
                .IsUnique()
                .HasDatabaseName("IX_Users_Email");

            builder.HasIndex(u => u.Username)
                .IsUnique()
                .HasDatabaseName("IX_Users_Username");

            // Seed data
            builder.HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Admin",
                    LastName = "User",
                    Email = "admin@vericmr.com",
                    Username = "admin",
                    PasswordHash = "$2a$11$8K1p/a0dL2LkqvMA87LzO.Ac5dvdW8aCO7yuiYxYGrI0rXG/a1u3W", // Admin123! hashed
                    Role = "Admin",
                    IsEmailConfirmed = true,
                    CreatedDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    IsDeleted = false // Admin user should not be deleted
                }
            );
        }
    }
}
