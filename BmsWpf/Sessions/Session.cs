using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BmsWpf.Sessions
{
    public sealed class Session
    {
        private static Session instance;

        private Session()
        {
            this.IsLogged = false;
        }

        public string Username { get; private set; }
        public bool IsLogged { get; private set; }

        public static Session Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Session();
                }
                return instance;
            }
        }

        public void SetUsername(string username)
        {
            this.Username = username;
            this.IsLogged = true;
        }
    }
}
