namespace BmsWpf.Services.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public class ContragentPostDto
    {
        public int Id { get; set; }
        [Required]
        [MinLength(1)]
        public string Name { get; set; }
        [Required]
        [MinLength(1)]
        public string PersonalIndentityNumber { get; set; }
        [Required]
        [MinLength(1)]
        public string PersonalVatNumber { get; set; }
        [Required]
        [MinLength(1)]
        public string Address { get; set; }
        [Required]
        [MinLength(1)]
        public string Telephone { get; set; }
        [Required]
        [MinLength(1)]
        public string Email { get; set; }
        [Required]
        [MinLength(1)]
        public string PersonForContact { get; set; }
        [Required]
        [MinLength(1)]
        public string BankDetails { get; set; }
        [Required]
        [MinLength(1)]
        public string Description { get; set; }
    }
}