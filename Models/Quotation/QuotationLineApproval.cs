using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cms_webapi.Models
{
    [Table("RII_QUOTATION_LINE_APPROVAL")]
    public class QuotationLineApproval : BaseEntity
    {
        [Required]
        public long QuotationLineId { get; set; }

        [ForeignKey("QuotationLineId")]
        public QuotationLine QuotationLine { get; set; } = null!;

        [Required]
        public long ApproverUserId { get; set; }
        [ForeignKey("ApproverUserId")]
        public User ApproverUser { get; set; } = null!;

        [Column(TypeName = "int")]
        public int ApprovalStatus { get; set; } = 0;
        // 0 = Pending
        // 1 = Approved
        // 2 = Rejected

        public DateTime ApprovalDate { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public string? ApprovalNote { get; set; }
    }

}
