using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BMS.Models
{
    public class Bank
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
        
        [Required]
        public string BIC { get; set; }

        public ICollection<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();
    }
}
