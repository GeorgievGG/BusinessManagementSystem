using AutoMapper;
using WpfApp1.Data;
using WpfApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.ViewModels;
using WpfApp1.SessionClass;

namespace WpfApp1.Services
{
    public class UserService
    {
        private BmsDbContext context;

        public UserService()
        {
            context = new BmsDbContext();
            //this.context = context;
        }

        //to be return interface later
        public void LoginUser(string username, string password)
        {
            var user = context.Employees.FirstOrDefault(e => e.FirstName == username && e.LastName == password);

            if (user == null)
            {
                throw new ArgumentException("The user does not exist!");
            }

            //change
            Session.Instance.SetUsername(user.FirstName);
            //change to HashedPassword

            var mappedEmp = Mapper.Map<Employee, LoginPageViewModel>(user);
        }
    }
}
