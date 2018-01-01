namespace BmsWpf.Services.Services
{
    using BMS.DataBaseModels;
    using BmsWpf.Services.Contracts;
    using BmsWpf.Services.DTOs;
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class UserService : IUserService
    {
        private IBmsData bmsData;

        public UserService(IBmsData bmsData)
        {
            this.bmsData = bmsData;
        }

        public ClearenceType LoginUser(string username, string password)
        {
            var user = this.GetUserByUsername(username);

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

        public string CreateUser(string username, string password, ClearenceType userType)
        {
            var existingUser = this.GetUserByUsername(username);

            if (existingUser != null)
            {
                throw new ArgumentException("Username already exists!");
            }

            var hashedPass = HashToSha1(password);

            var newUser = new User
            {
                Username = username,
                Password = hashedPass,
                Type = userType
            };

            bmsData.Users.Add(newUser);
            bmsData.SaveChanges();

            return "User has been successfully registered!";
        }

        public string HashToSha1(string password)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(password));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }

        public IQueryable<string> GetUsers()
        {
            return bmsData.Users.All().Select(x => $"{x.Username}|{x.Type}");
        }

        public IQueryable<UserListDto> GetUsernames()
        {
            return bmsData.Users.All().Select(x => new UserListDto()
                                                {
                                                    Id = x.Id,
                                                    Username = x.Username
                                                });
        }

        public string ModifyUser(string username, ClearenceType selectedClearenceType)
        {
            var user = this.GetUserByUsername(username);
            user.Type = selectedClearenceType;

            bmsData.Users.Update(user);

            bmsData.SaveChanges();

            return $"User {username} clearance type changed successfully to {selectedClearenceType}";
        }

        private User GetUserByUsername(string username)
        {
            var user = this.bmsData.Users.All().FirstOrDefault(x => x.Username == username);

            return user;
        }
    }
}
