using System;
using System.ComponentModel.DataAnnotations;

namespace cms_webapi.DTOs
{
    public class DistrictGetDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ERPCode { get; set; }
        public long CityId { get; set; }
        public string? CityName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        
        // Full user information properties
        public string? CreatedByFullUser { get; set; }
        public string? UpdatedByFullUser { get; set; }
        public string? DeletedByFullUser { get; set; }
    }

    public class DistrictCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(10)]
        public string? ERPCode { get; set; }

        [Required]
        public long CityId { get; set; }
    }

    public class DistrictUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(10)]
        public string? ERPCode { get; set; }

        [Required]
        public long CityId { get; set; }
    }
}
