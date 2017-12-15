using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BMS.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        [Required]
        public string VatNumber { get; set; }

        public string PersonToContact { get; set; }

        public string Description { get; set; }


        public ICollection<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();
        public ICollection<Inquiry> Inquiries { get; set; } = new List<Inquiry>();
        public ICollection<Project> Projects { get; set; } = new List<Project>();
        public ICollection<InvoiceClient> Invoices { get; set; } = new List<InvoiceClient>();

    }
}