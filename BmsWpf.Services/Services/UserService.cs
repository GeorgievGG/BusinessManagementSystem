namespace BmsWpf.Services.Services
{
    using BMS.DataBaseModels;
    using BmsWpf.Services.Contracts;
    using System;
    using System.Linq;

    public class UserService
    {
        private IBmsData bmsData;

        public UserService(IBmsData bmsData)
        {
            this.bmsData = bmsData;
            //this.context = context;
        }

        //to be return interface later
        public ClearenceType LoginUser(string username, string password)
        {
            var users = bmsData.Users.All();
            var user = users.FirstOrDefault(e => e.Username == username);

            if (user == null)
            {
                throw new ArgumentException("Invalid Username. Try again!");
            }

            if (password != user.Password)
            {
                throw new ArgumentException("Invalid Password. Try again!");
            }

            return user.Type;
        }
    }
}
