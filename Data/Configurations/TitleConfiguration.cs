using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using cms_webapi.Models;

namespace cms_webapi.Data.Configurations
{
    public class TitleConfiguration : IEntityTypeConfiguration<Title>
    {
        public void Configure(EntityTypeBuilder<Title> builder)
        {
            // Table name
            builder.ToTable("RII_TITLE");

            // Primary key
            builder.HasKey(e => e.Id);

            // Base properties configuration
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.CreatedDate)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(e => e.UpdatedDate)
                .IsRequired(false);

            builder.Property(e => e.DeletedDate)
                .IsRequired(false);

            builder.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            // Title specific properties
            builder.Property(e => e.TitleName)
                .HasMaxLength(50)
                .IsRequired();

            // Relationship configuration
            builder.HasMany(e => e.Contacts)
                .WithOne(c => c.Titles)
                .HasForeignKey(c => c.TitleId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(e => e.TitleName)
                .HasDatabaseName("IX_Title_TitleName");

            builder.HasIndex(e => e.IsDeleted)
                .HasDatabaseName("IX_Title_IsDeleted");
        }
    }
}
