namespace BMS.DataBaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Project
    {
        public Project()
        {
            this.ClientInvoices = new List<ClientInvoice>();
            this.Payments = new List<Payment>();
            this.SuplierInvoices = new List<SupplierInvoice>();
            this.Notes = new List<Note>();
            this.Events = new List<CalendarEvent>();
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
        public DateTime? EndDate { get; set; }
        public DateTime DeadLine { get; set; }
        
        public int ContragentId { get; set; }
        public Contragent Contragent { get; set; }

        //public string ContactPerson { get; set; }
        //public string ContactPhone { get; set; }


        public ICollection<Contragent> Suppliers { get; set; }
        public ICollection<ClientInvoice> ClientInvoices { get; set; }
        public ICollection<SupplierInvoice> SuplierInvoices { get; set; }

        public ICollection<Payment> Payments { get; set; }

        public ICollection<Note> Notes { get; set; }
        public ICollection<CalendarEvent> Events { get; set; }
    }
}
