namespace BmsWpf.Services.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public class UserListDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }

        public override string ToString()
        {
            return this.Username;
        }
    }
}
