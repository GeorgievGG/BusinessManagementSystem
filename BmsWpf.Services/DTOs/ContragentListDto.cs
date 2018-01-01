namespace BmsWpf.Services.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public class ContragentListDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string NameAndIdentity { get; set; }

        public override string ToString()
        {
            return this.NameAndIdentity;
        }
    }
}
