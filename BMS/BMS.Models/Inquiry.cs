using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BMS.Models
{
    public class Inquiry
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int ClientId { get; set; }

        [Required]
        public Client Client { get; set; }
        
        [Required]
        public DateTime Date { get; set; }

        public ICollection<Offer> Offers { get; set; } = new List<Offer>();
    }
}
