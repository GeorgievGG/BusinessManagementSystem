namespace BMS.Models
{
    public class BankAccount
    {
        public int Id { get; set; }

        public string AccountNumber { get; set; }

        public int ContragentId { get; set; }
        public Contragent Contragent { get; set; }

        public int BankId { get; set; }
        public Bank Bank { get; set; }
    }
}
