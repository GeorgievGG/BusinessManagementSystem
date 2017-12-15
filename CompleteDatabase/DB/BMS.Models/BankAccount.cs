namespace BMS.Models
{
    public class BankAccount
    {
        public int Id { get; set; }

        public string AccountNumber { get; set; }

        public int? SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public int? ClientId { get; set; }
        public Client Client { get; set; }

        public int BankId { get; set; }
        public Bank Bank { get; set; }
    }
}
