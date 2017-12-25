namespace BmsWpf.Sessions
{
    using BmsWpf.Services.Contracts;
    using BmsWpf.Services.Services;

    public sealed class Session
    {
        private static Session instance;
        private UserService userService;

        private Session()
        {
            this.IsLogged = false;
        }

        public string Username { get; private set; }
        public bool IsLogged { get; private set; }
        public IBmsData BmsData { get; private set; }

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

        public UserService UserService
        {
            get
            {
                if (userService == null)
                {
                    userService = new UserService(BmsData);
                }
                return userService;
            }
        }

        public void SetUsername(string username)
        {
            this.Username = username;
            this.IsLogged = true;
        }

        public void SetBmsData(IBmsData bmsData)
        {
            this.BmsData = bmsData;
        }
    }
}
