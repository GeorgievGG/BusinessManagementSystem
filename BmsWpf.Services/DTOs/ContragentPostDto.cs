namespace BmsWpf.Services.DTOs
{
    public class ContragentPostDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PersonalIndentityNumber { get; set; }
        public string PersonalVatNumber { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string PersonForContact { get; set; }
        public string BankDetails { get; set; }
        public string Description { get; set; }
    }
}