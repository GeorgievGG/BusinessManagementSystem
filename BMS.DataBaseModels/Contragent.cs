namespace BMS.DataBaseModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Contragent
    {
        public Contragent()
        {
            this.ClientInvoices = new List<Invoice>();
            this.ClientPayments = new List<Payment>();
            this.SupplierInvoices = new List<Invoice>();
            this.SupplierPayments = new List<Payment>();
            this.Projects = new List<Project>();
            this.Inquiries = new List<Inquiry>();
            this.Offers = new List<Offer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(250,MinimumLength = 3)]
        public string Name { get; set; }

        public int? PersonalIndentityNumber { get; set; }

        public string PersonalVatNumber { get; set; }

        [StringLength(250, MinimumLength = 3)]
        public string Address { get; set; }
        [StringLength(250, MinimumLength = 3)]
        public string Telephone { get; set; }
        [StringLength(250, MinimumLength = 3)]
        public string Email { get; set; }
        [StringLength(250, MinimumLength = 3)]
        public string PersonForContact { get; set; }
        [StringLength(250, MinimumLength = 3)]
        public string BankDetails { get; set; }

        public string Description { get; set; }

        public int? ProjectId { get; set; }
        public Project Project { get; set; }

        public int? InvoiceId { get; set; }

        public ICollection<Invoice> ClientInvoices { get; set; }
        public ICollection<Invoice> SupplierInvoices { get; set; }

        public ICollection<Payment> ClientPayments { get; set; }
        public ICollection<Payment> SupplierPayments { get; set; }

        public ICollection<Project> Projects { get; set; }
        public ICollection<Offer> Offers { get; set; }
        public ICollection<Inquiry> Inquiries { get; set; }
    }
}
