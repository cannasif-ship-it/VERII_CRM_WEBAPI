using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace cms_webapi.Models
{
    [Table("RII_COUNTRY")]
    public class Country : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty; // UlkeAdi

        [MaxLength(5)]
        public string Code { get; set; } = string.Empty; // UlkeKodu (ISO)

        [MaxLength(10)]
        public string? ERPCode { get; set; } // Netsis veya ERP eşleşmesi

        // Navigation
        public ICollection<City>? Cities { get; set; }
        // Navigation
        public ICollection<Contact>? Contacts { get; set; }
    }
}
