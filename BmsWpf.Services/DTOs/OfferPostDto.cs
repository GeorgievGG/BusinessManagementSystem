namespace BmsWpf.Services.DTOs
{
    using System;

    public class OfferPostDto
    {
        private int creatorId;
        private int clientId;
        private int inquiryId;
        private string description;

        public int Id { get; set; }
        public int CreatorId
        {
            get
            {
                return this.creatorId;
            }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("You haven't chosen a Creator!");
                }
                this.creatorId = value;
            }
        }
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
                    throw new ArgumentException("You haven't chosen a Client!");
                }
                this.clientId = value;
            }
        }
        public int InquiryId
        {
            get
            {
                return this.inquiryId;
            }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("You haven't chosen an Inquiry!");
                }
                this.inquiryId = value;
            }
        }
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Offer should have a description!");
                }
                this.description = value;
            }
        }
        public DateTime Date { get; set; } //Има автоматично зададена дата.
    }
}