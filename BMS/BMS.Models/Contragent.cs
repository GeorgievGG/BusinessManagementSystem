using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BMS.Models
{
    public class Contragent
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? PersonalIdentityNumber { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        [Required]
        public string VatNumber { get; set; }

        [Required]
        public string PersonForContact { get; set; }

        public string Description { get; set; }

        public ICollection<Project> ProjectsClient { get; set; } = new List<Project>();

        public ICollection<InvoiceClient> InvoiceClients { get; set; } = new List<InvoiceClient>();

        public ICollection<InvoiceSupplier> InvoiceSuppliers { get; set; } = new List<InvoiceSupplier>();

        public ICollection<ProjectSupplier> ProjectsSuppliers { get; set; } = new List<ProjectSupplier>();

        public ICollection<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();

        public ICollection<Inquiry> Inquiries { get; set; } = new List<Inquiry>();
    }
}