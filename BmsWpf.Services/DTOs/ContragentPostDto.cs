namespace BmsWpf.Services.DTOs
{
    using System;
    using System.Text.RegularExpressions;

    public class ContragentPostDto
    {
        private string name;
        private string personalIndentityNumber;
        private string personalVatNumber;

        private string town;

        private string address;

        private string telephone;

        private string email;

        private string personForContact;

        private string bankDetails;

        private string description; 

        public int Id { get; set; }
        public string Name
        {
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
        public string PersonalIndentityNumber
        {
            get
            {
                return this.personalIndentityNumber;
            }
            set
            {
                var patern = @"\d+";
                var isValid = Regex.IsMatch(value, patern);
                if (isValid == false || value.Length < 9 || string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("The number is must be above 9 digits");
                }
                this.personalIndentityNumber = value;
            }
        }
        public string PersonalVatNumber
        {
            get
            {
                return this.personalVatNumber;
            }
            set
            {
                var patern = @"[A-Z]{2}\d+";
                var isValid = Regex.IsMatch(value, patern);
                if (isValid == false || value.Length < 11 || string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("The VAT number is not valid");
                }
                this.personalVatNumber = value;
            }
        }
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
        public string Address
        {
            get
            {
                return this.address;
            }
            set
            {
                if (value.Length < 3 || string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("The address have to be more then 3 symbols");
                }

                this.address = value;
            }
        }
        public string Telephone {
            get
            {
                return this.telephone;
            }
            set
            {
                var patern = @"\d+";
                var isValid = Regex.IsMatch(value, patern);
                if (isValid == false || value.Length < 9  || string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("The telephone is not valid");
                }
                this.telephone = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                var patern = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                             @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
                var isValid = Regex.IsMatch(value, patern);
                if (isValid == false || string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("The email is not valid");
                }
                this.email = value;
            }
        }
        public string PersonForContact
        {
            get
            {
                return this.personForContact;
            }

            set
            {
                if (value.Length < 3 || string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("Person for contact have to be more then 3 symbols");
                }

                this.personForContact = value;
            }
        }
        public string BankDetails
        {
            get
            {
                return this.bankDetails;
            }
            set
            {
                //var patern = @"[A - Z]{2}\d{2}[A-Z]{4}[A-Z0-9] {14}";
                //var isValid = Regex.IsMatch(this.bankDetails, patern);
                //if (isValid == false || string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                //{
                //    throw new ApplicationException("Bank account have to be inn format BG12BGTY12121212121212");
                //}

                if (value.Length < 3 || string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("Bank details have to be more then 3 symbols");
                }

                this.bankDetails = value;
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
                if (value.Length < 3 || string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("Description have to be more then 3 symbols");
                }

                this.description = value;
            }
        }
    }
}