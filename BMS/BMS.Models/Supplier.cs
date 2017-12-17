using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BMS.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        [Required]
        public string VatNumber { get; set; }

        [Required]
        public string PersonForContact { get; set; }

        public string Description { get; set; }

        public int? ProjectId { get; set; }
        public Project Project { get; set; }

        public ICollection<InvoiceSupplier> Invoices { get; set; } = new List<InvoiceSupplier>();

        public ICollection<ProjectSupplier> ProjectsSuppliers { get; set; } = new List<ProjectSupplier>();

        public ICollection<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();
    }
}
