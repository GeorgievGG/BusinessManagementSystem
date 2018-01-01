namespace BmsWpf.Services.DTOs
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class InquiriesMainWindowDto
    {
        public int Id { get; set; }
        [Required]
        public UserListDto Creator { get; set; }
        [Required]
        public ContragentListDto Client { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
