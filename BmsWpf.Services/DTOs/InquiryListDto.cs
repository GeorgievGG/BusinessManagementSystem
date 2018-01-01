namespace BmsWpf.Services.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public class InquiryListDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }

        public override string ToString()
        {
            return this.Description;
        }
    }
}
