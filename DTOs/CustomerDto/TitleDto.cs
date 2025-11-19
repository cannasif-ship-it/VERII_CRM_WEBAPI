using System;
using System.ComponentModel.DataAnnotations;

namespace cms_webapi.DTOs
{
    public class TitleDto
    {
        public int Id { get; set; }
        public string TitleName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public List<ContactDto>? Contacts { get; set; }
    }

    public class CreateTitleDto
    {
        [Required]
        [MaxLength(50)]
        public string TitleName { get; set; } = string.Empty;
    }

    public class UpdateTitleDto
    {
        [Required]
        [MaxLength(50)]
        public string TitleName { get; set; } = string.Empty;
    }
}
