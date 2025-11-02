using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using cms_webapi.Models;

namespace cms_webapi.Data.Configurations
{
    public class QuotationConfiguration : IEntityTypeConfiguration<Quotation>
    {
        public void Configure(EntityTypeBuilder<Quotation> builder)
        {
            builder.ToTable("RII_QUOTATION");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.PotentialCustomerId)
                .HasColumnName("POTENTIAL_CUSTOMER_ID");

            builder.Property(e => e.ErpCustomerCode)
                .HasColumnName("ERP_CUSTOMER_CODE")
                .HasMaxLength(50);

            builder.Property(e => e.DeliveryDate)
                .HasColumnName("DELIVERY_DATE");

            builder.Property(e => e.ShippingAddressId)
                .HasColumnName("SHIPPING_ADDRESS_ID");

            builder.Property(e => e.RepresentativeId)
                .HasColumnName("REPRESENTATIVE_ID");

            builder.Property(e => e.Status)
                .HasColumnName("STATUS");

            builder.Property(e => e.Description)
                .HasColumnName("DESCRIPTION")
                .HasMaxLength(500);

            builder.Property(e => e.PaymentTypeId)
                .HasColumnName("PAYMENT_TYPE_ID");

            builder.Property(e => e.OfferType)
                .HasColumnName("OFFER_TYPE")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.OfferDate)
                .HasColumnName("OFFER_DATE");

            builder.Property(e => e.OfferNo)
                .HasColumnName("OFFER_NO")
                .HasMaxLength(50);

            builder.Property(e => e.RevisionNo)
                .HasColumnName("REVISION_NO")
                .HasMaxLength(50);

            builder.Property(e => e.RevisionId)
                .HasColumnName("REVISION_ID");

            builder.Property(e => e.Currency)
                .HasColumnName("CURRENCY")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.ExchangeRate)
                .HasColumnName("EXCHANGE_RATE");

            builder.Property(e => e.CreatedDate)
                .HasColumnName("CREATED_DATE")
                .IsRequired();

            builder.Property(e => e.UpdatedDate)
                .HasColumnName("UPDATED_DATE");

            builder.Property(e => e.CreatedBy)
                .HasColumnName("CREATED_BY")
                .HasMaxLength(50);

            builder.Property(e => e.UpdatedBy)
                .HasColumnName("UPDATED_BY")
                .HasMaxLength(50);

            builder.Property(e => e.DeletedBy)
                .HasColumnName("DELETED_BY")
                .HasMaxLength(50);

            // Foreign Key Relationships
            builder.HasOne(e => e.PotentialCustomer)
                .WithMany()
                .HasForeignKey(e => e.PotentialCustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.ShippingAddress)
                .WithMany()
                .HasForeignKey(e => e.ShippingAddressId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Representative)
                .WithMany()
                .HasForeignKey(e => e.RepresentativeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.PaymentType)
                .WithMany()
                .HasForeignKey(e => e.PaymentTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(e => e.PotentialCustomerId);
            builder.HasIndex(e => e.ShippingAddressId);
            builder.HasIndex(e => e.RepresentativeId);
            builder.HasIndex(e => e.PaymentTypeId);
            builder.HasIndex(e => e.Status);
            builder.HasIndex(e => e.OfferDate);
            builder.HasIndex(e => e.CreatedDate);
            builder.HasIndex(e => e.CreatedBy);
            builder.HasIndex(e => e.UpdatedBy);
            builder.HasIndex(e => e.DeletedBy);
        }
    }
}
