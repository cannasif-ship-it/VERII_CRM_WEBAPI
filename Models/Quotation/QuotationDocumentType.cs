using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cms_webapi.Models
{
    [Table("RII_QUOTATION_DOCUMENT_TYPE")]
    public class QuotationDocumentType : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(30)")]
        public string DocumentTypeName { get; set; } = null!; // Document type name (örnek: SAT, TEK, T)

        public long customerTypeId { get; set; } // Customer type id (örnek: 1, 2, 3)
        [ForeignKey("customerTypeId")]
        public CustomerType CustomerType { get; set; } = null!; // Customer type (örnek: 1, 2, 3)

        [MaxLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        public string? Description { get; set; } // Açıklama


    }
}
