namespace BmsWpf.Services.DTOs
{
    using System;
    using System.Text.RegularExpressions;

    public class ProjectPostDto
    {
        private string name;
        private int offerId;
        private int inquiryId;
        private int creatorId;
        private int clientId;
        private string contactPerson;
        private string contactPhone;


        public int Id { get; set; }
        public string Name {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length < 2 || string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("The name have to be more then 3 symbols");
                }

                this.name = value;
            }
        }

        public int OfferId {
            get
            {
                return this.offerId;
            }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("You haven't chosen an offer.");
                }

                this.offerId = value;
            }
        }

        public int InquiryId {
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

        public int CreatorId {
            get
            {
                return this.creatorId;
            }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("You haven't chosen an creator!");
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
        public string ContactPerson
        {
            get
            {
                return this.contactPerson;
            }
            set
            {
                if (value.Length < 3 || string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("Description have to be more then 3 symbols");
                }
                this.contactPerson = value;
            }
        }
        public string ContactPhone
        {
            get
            {
                return this.contactPhone;
            }
            set
            {
                var patern = @"\d+";
                var isValid = Regex.IsMatch(this.contactPhone, patern);
                if (isValid == false || this.contactPhone.Length < 9 || string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("The telephone is not valid");
                }
                this.contactPhone = value;
            }
        }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime Deadline { get; set; }
    }
}