using System;
using System.ComponentModel.DataAnnotations;

namespace cms_webapi.DTOs
{
    public class QuotationDocumentTypeDto : BaseEntityDto
    {
        public string DocumentTypeName { get; set; } = string.Empty;
        public long customerTypeId { get; set; }
        public string? Description { get; set; }
    }

    public class CreateQuotationDocumentTypeDto
    {
        [Required]
        [MaxLength(30)]
        public string DocumentTypeName { get; set; } = string.Empty;
        [Required]
        public long customerTypeId { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
    }

    public class UpdateQuotationDocumentTypeDto
    {
        [Required]
        [MaxLength(30)]
        public string DocumentTypeName { get; set; } = string.Empty;
        [Required]
        public long customerTypeId { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
    }
}
