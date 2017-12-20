using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BmsWpf.Services
{
    using BmsWpf.Sessions;
    using BmsWpf.ViewModels;

    using BMS.DataBaseData;
    using BMS.DataBaseModels;

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

            //change
            Session.Instance.SetUsername(user.Username);
            //change to HashedPassword

            // var mappedEmp = Mapper.Map<User, LoginFormViewModel>(user);
        }
    }
}
