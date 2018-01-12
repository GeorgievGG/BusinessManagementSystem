namespace BmsWpf.Services.DTOs
{
    using System;

    public class InvoicePostDto
    {
        private int clientId;
        private int supplierId;
        private int projectId;
        private string town;
        private string text;
        private string bank;
        private decimal price;


        public int Id { get; set; }

        public int ClientId {
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
        public int SupplierId {
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
        public int ProjectId {
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

        public int InvoiceNum { get; set; }
        public DateTime Date { get; set; }
        public string Town
        {
            get
            {
                return this.town;
            }
            set
            {
                if (value.Length < 2 || string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("Town name have to be more then 3 symbols");
                }

                this.town = value;
            }
        }

        public string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                if (value.Length < 3 || string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("Description have to be more then 3 symbols");
                }

                this.text = value;
            }
        }
        public string BankRequisits
        {
            get
            {
                return this.bank;
            }
            set
            {

                if (value.Length < 3 || string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("Bank details have to be more then 3 symbols");
                }

                this.bank = value;
            }
        }

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