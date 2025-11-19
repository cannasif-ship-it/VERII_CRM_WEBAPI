using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cms_webapi.Models
{
 [Table("RII_QUOTATION_APPROVAL")]
public class QuotationApproval : BaseEntity
{
    public long QuotationId { get; set; }

    [ForeignKey("QuotationId")]
    public Quotation Quotation { get; set; } = null!;

    public long ApproverUserId { get; set; } // Onaycı kullanıcı
    [ForeignKey("ApproverUserId")]
    public User ApproverUser { get; set; } = null!;

    [Column(TypeName = "int")]
    public int ApprovalStatus { get; set; } = 0;
    // 0 = Pending, 1 = Approved, 2 = Rejected, 3 = Canceled, 4 = Expired

    public DateTime? ApprovalDate { get; set; }

    [Column(TypeName = "nvarchar(500)")]
    public string? ApprovalNote { get; set; } // Onaycı notu
}

}
