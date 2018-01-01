using System.ComponentModel.DataAnnotations;

namespace BmsWpf.Services.DTOs
{
    public class ContragentInfoForInquiryDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Contact { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNum { get; set; }
    }
}
