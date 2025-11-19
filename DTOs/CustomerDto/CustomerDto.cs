using System;
using System.ComponentModel.DataAnnotations;

namespace cms_webapi.DTOs
{
    public class CustomerGetDto
    {
        public long Id { get; set; }
        public string CustomerCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? TaxNumber { get; set; }
        public string? TaxOffice { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public long CountryId { get; set; }
        public string? CountryName { get; set; }
        public long CityId { get; set; }
        public string? CityName { get; set; }
        public long DistrictId { get; set; }
        public string? DistrictName { get; set; }
        public long CustomerTypeId { get; set; }
        public string? CustomerTypeName { get; set; }
        public string? ERPCode { get; set; }
        public DateTime? CompletedDate { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsApproved { get; set; }
        public bool IsERPIntegrated { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        
        // Full user information properties
        public string? CreatedByFullUser { get; set; }
        public string? UpdatedByFullUser { get; set; }
        public string? DeletedByFullUser { get; set; }
    }

    public class CustomerCreateDto
    {
        [Required]
        [MaxLength(20)]
        public string CustomerCode { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(15)]
        public string? TaxNumber { get; set; }

        [MaxLength(100)]
        public string? TaxOffice { get; set; }

        [MaxLength(500)]
        public string? Address { get; set; }

        [MaxLength(20)]
        public string? Phone { get; set; }

        [MaxLength(100)]
        [EmailAddress]
        public string? Email { get; set; }

        [MaxLength(100)]
        public string? Website { get; set; }

        [Required]
        public long CountryId { get; set; }

        [Required]
        public long CityId { get; set; }

        [Required]
        public long DistrictId { get; set; }

        [Required]
        public long CustomerTypeId { get; set; }

        [MaxLength(20)]
        public string? ERPCode { get; set; }

        public bool IsCompleted { get; set; } = false;
        public bool IsApproved { get; set; } = false;
        public bool IsERPIntegrated { get; set; } = false;
    }

    public class CustomerUpdateDto
    {
        [Required]
        [MaxLength(20)]
        public string CustomerCode { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(15)]
        public string? TaxNumber { get; set; }

        [MaxLength(100)]
        public string? TaxOffice { get; set; }

        [MaxLength(500)]
        public string? Address { get; set; }

        [MaxLength(20)]
        public string? Phone { get; set; }

        [MaxLength(100)]
        [EmailAddress]
        public string? Email { get; set; }

        [MaxLength(100)]
        public string? Website { get; set; }

        [Required]
        public long CountryId { get; set; }

        [Required]
        public long CityId { get; set; }

        [Required]
        public long DistrictId { get; set; }

        [Required]
        public long CustomerTypeId { get; set; }

        [MaxLength(20)]
        public string? ERPCode { get; set; }

        public DateTime? CompletedDate { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsApproved { get; set; }
        public bool IsERPIntegrated { get; set; }
    }
}
