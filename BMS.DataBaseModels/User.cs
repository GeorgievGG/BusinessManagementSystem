namespace BMS.DataBaseModels
{
   public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ClearenceType Type { get; set; }
    }
}
