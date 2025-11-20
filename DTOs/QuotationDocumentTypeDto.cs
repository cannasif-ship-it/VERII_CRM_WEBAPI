using System;
using System.ComponentModel.DataAnnotations;

namespace cms_webapi.DTOs
{
    public class QuotationDocumentTypeDto
    {
        public long Id { get; set; }
        public string DocumentTypeName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class CreateQuotationDocumentTypeDto
    {
        [Required]
        [MaxLength(30)]
        public string DocumentTypeName { get; set; } = string.Empty;
        [MaxLength(500)]
        public string? Description { get; set; }
    }

    public class UpdateQuotationDocumentTypeDto
    {
        [Required]
        [MaxLength(30)]
        public string DocumentTypeName { get; set; } = string.Empty;
        [MaxLength(500)]
        public string? Description { get; set; }
    }
}