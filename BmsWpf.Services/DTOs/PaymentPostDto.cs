namespace BmsWpf.Services.DTOs
{
    using System;

    public class PaymentPostDto
    {
        private int clientId;
        private int contragentId;
        private int projectId;
        private decimal price;

        public int Id { get; set; }

        public int ContragentId
        {
            get
            {
                return this.contragentId;
            }
            set
            {
                if (value == 0)
                {
                    throw new ApplicationException("You haven't chosen a Contragent!");
                }
                this.clientId = value;
            }
        }

        public int ProjectId
        {
            get
            {
                return this.projectId;
            }
            set
            {
                if (value == 0)
                {
                    throw new ApplicationException("You haven't chosen a project!");
                }

                this.projectId = value;
            }
        }

        public DateTime Date { get; set; }
        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ApplicationException("Price have to be a possitive number");
                }
                this.price = value;
            }
        }
        public decimal Vat { get; set; }
        public decimal Total { get; set; }
    }
}
