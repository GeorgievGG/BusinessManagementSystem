namespace BmsWpf.Sessions
{
    using BmsWpf.Services.Services;

    public sealed class Session
    {
        private static Session instance;

        private Session()
        {
            this.IsLogged = false;
        }

        public string Username { get; private set; }
        public bool IsLogged { get; private set; }
        public string LastOpenWindow { get; private set; }

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

        public void SetLastOpenWindow(string windowName)
        {
            this.LastOpenWindow = windowName;
        }

        public void Logout()
        {
            this.Username = null;
            this.IsLogged = false;
        }
    }
}
