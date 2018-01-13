namespace BmsWpf.Services.DTOs
{
    using System;

    public class PaymentPostDto
    {
        private int clientId;
        private int supplierId;
        private int projectId;
        private decimal price;

        public int Id { get; set; }

        public int ClientId
        {
            get
            {
                return this.clientId;
            }
            set
            {
                if (value == 0)
                {
                    throw new ApplicationException("You haven't chosen a Client!");
                }
                this.clientId = value;
            }
        }
        public int SupplierId
        {
            get
            {
                return this.supplierId;
            }
            set
            {
                if (value == 0)
                {
                    throw new ApplicationException("You haven't chosen a Supplier!");
                }
                this.supplierId = value;
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
