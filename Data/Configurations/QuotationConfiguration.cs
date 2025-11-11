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
            // Key is defined via BaseEntity annotations; map column name
            builder.Property(e => e.Id)
                .HasColumnName("ID");

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
                .HasColumnName("CREATED_BY");

            builder.Property(e => e.UpdatedBy)
                .HasColumnName("UPDATED_BY");

            builder.Property(e => e.DeletedBy)
                .HasColumnName("DELETED_BY");

            // BaseHeaderEntity fields (approval & ERP integration)
            builder.Property(e => e.CompletionDate)
                .HasColumnName("COMPLETION_DATE");

            builder.Property(e => e.IsCompleted)
                .HasColumnName("IS_COMPLETED")
                .HasDefaultValue(false);

            builder.Property(e => e.IsPendingApproval)
                .HasColumnName("IS_PENDING_APPROVAL")
                .HasDefaultValue(false);

            builder.Property(e => e.ApprovalStatus)
                .HasColumnName("APPROVAL_STATUS");

            builder.Property(e => e.RejectedReason)
                .HasColumnName("REJECTED_REASON")
                .HasMaxLength(250);

            builder.Property(e => e.ApprovedByUserId)
                .HasColumnName("APPROVED_BY_USER_ID");

            builder.HasOne(e => e.ApprovedByUser)
                .WithMany()
                .HasForeignKey(e => e.ApprovedByUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(e => e.ApprovalDate)
                .HasColumnName("APPROVAL_DATE");

            builder.Property(e => e.IsERPIntegrated)
                .HasColumnName("IS_ERP_INTEGRATED")
                .HasDefaultValue(false);

            builder.Property(e => e.ERPIntegrationNumber)
                .HasColumnName("ERP_INTEGRATION_NUMBER")
                .HasMaxLength(100);

            builder.Property(e => e.LastSyncDate)
                .HasColumnName("LAST_SYNC_DATE");

            builder.Property(e => e.CountTriedBy)
                .HasColumnName("COUNT_TRIED_BY")
                .HasDefaultValue(0);

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

            builder.HasIndex(e => e.ApprovedByUserId);
            builder.HasIndex(e => e.ApprovalStatus);
            builder.HasIndex(e => e.ApprovalDate);
            builder.HasIndex(e => e.IsCompleted);
        }
    }
}
