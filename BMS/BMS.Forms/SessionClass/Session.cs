namespace WpfApp1.SessionClass
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
