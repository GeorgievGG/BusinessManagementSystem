namespace BmsWpf.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class UserModel
    {
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
       
    }
}
