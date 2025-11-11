using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using cms_webapi.Models;

namespace cms_webapi.Data.Configurations
{
    public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            // Primary key is defined via data annotations on BaseEntity.Id
            // Avoid configuring keys on derived types to prevent inheritance key conflicts.

            // Base properties configuration

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

            // Audit fields are nullable long FKs; no MaxLength configuration

            // Foreign key relationships with NoAction to prevent cascade cycles
            builder.HasOne(e => e.CreatedByUser)
                .WithMany()
                .HasForeignKey(e => e.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.UpdatedByUser)
                .WithMany()
                .HasForeignKey(e => e.UpdatedBy)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.DeletedByUser)
                .WithMany()
                .HasForeignKey(e => e.DeletedBy)
                .OnDelete(DeleteBehavior.NoAction);

            // Global query filter for soft delete is applied on root entity types (e.g., BaseHeaderEntity)

            // Configure specific entity
            ConfigureEntity(builder);
        }

        protected abstract void ConfigureEntity(EntityTypeBuilder<T> builder);
    }
}
