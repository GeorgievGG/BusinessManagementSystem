namespace BmsWpf.Services.DTOs
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class OfferPostDto
    {
        public int Id { get; set; }
        [Required]
        public int CreatorId { get; set; }
        [Required]
        public int ClientId { get; set; }
        [Required]
        public int InquiryId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}