namespace BmsWpf.Services
{
    using System;
    using System.Linq;
    using BMS.DataBaseData;
    using BmsWpf.Sessions;

    public class UserService
    {
        private BmsContex context;

        public UserService()
        {
            context = new BmsContex();
            //this.context = context;
        }

        //to be return interface later
        public void LoginUser(string username, string password)
        {
            var user = context.Users.FirstOrDefault(e => e.Username == username && e.Password == password);

            if (user == null)
            {
                throw new ArgumentException("The user does not exist!");
            }
            
            Session.Instance.SetUsername(user.Username);
        }
    }
}
