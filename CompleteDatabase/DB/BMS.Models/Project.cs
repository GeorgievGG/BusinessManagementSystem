﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BMS.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime DeadLine { get; set; }

        public DateTime? EndDate { get; set; }

        public int? ContractId { get; set; }
        public Contract Contract { get; set; }

        public int OfferId { get; set; }
        public Offer Offer { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public ICollection<InvoiceClient> InvoicesClient { get; set; } = new List<InvoiceClient>();

        public ICollection<ProjectSupplier> ProjectsSuppliers { get; set; } = new List<ProjectSupplier>();
    }
}
