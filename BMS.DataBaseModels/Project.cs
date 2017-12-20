namespace BMS.DataBaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Project
    {
        public Project()
        {
            this.ClientInvoices = new List<Invoice>();
            this.ClientPayments = new List<Payment>();
            this.SuplierInvoices = new List<Invoice>();
            this.SuplierPayments = new List<Payment>();
            this.Notes = new List<Note>();
            this.Suppliers = new List<Contragent>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 3)]
        public string Name { get; set; }

        public int? CreatorId { get; set; }
        public User Creator { get; set; }

        public int? InquiryId { get; set; }
        public Inquiry Inquiry { get; set; }

        public int? OfferId { get; set; }
        public Offer Offer { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DeadLine { get; set; }
        
        public int ClientId { get; set; }
        public Contragent Client { get; set; }

        public int? SuplierId { get; set; }

        public ICollection<Contragent> Suppliers { get; set; }
        public ICollection<Invoice> ClientInvoices { get; set; }
        public ICollection<Invoice> SuplierInvoices { get; set; }

        public ICollection<Payment> ClientPayments { get; set; }
        public ICollection<Payment> SuplierPayments { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}
