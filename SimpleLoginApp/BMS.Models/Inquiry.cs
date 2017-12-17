using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WpfApp1.Models
{
    public class Inquiry
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int ClientId { get; set; }

        [Required]
        public Contragent Client { get; set; }
        
        [Required]
        public DateTime Date { get; set; }

        public ICollection<Offer> Offers { get; set; } = new List<Offer>();
    }
}
