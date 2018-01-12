namespace BmsWpf.Services.DTOs
{
    using System;

    public class ProjectPostDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OfferId { get; set; }
        public int InquiryId { get; set; }
        public int CreatorId { get; set; }
        public int ClientId { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPhone { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime Deadline { get; set; }
    }
}