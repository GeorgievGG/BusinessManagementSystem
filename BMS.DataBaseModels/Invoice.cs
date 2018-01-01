namespace BMS.DataBaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Invoice
    {

        [Key]
        public int Id { get; set; }
        
        public DateTime Date { get; set; }

        public decimal Price { get; set; }
        public decimal Vat { get; set; }
        public decimal Total { get; set; }

        public int ContragentId { get; set; }
        public Contragent SuplierContragent { get; set; }
        public Contragent ClientContragent { get; set; }


    }
}
