using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BMS.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public ClearenceType Clearence { get; set; }
        

        public ICollection<Project> Projects { get; set; } = new List<Project>();
        public ICollection<Contract> CreatedContracts { get; set; } = new List<Contract>();
        public ICollection<Offer> CreatedOffers { get; set; } = new List<Offer>();
    }
}
