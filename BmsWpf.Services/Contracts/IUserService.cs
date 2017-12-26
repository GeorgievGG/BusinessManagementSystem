using BMS.DataBaseModels;

namespace BmsWpf.Services.Contracts
{
    public interface IUserService
    {
        ClearenceType LoginUser(string username, string password);
        string CreateUser(string username, string password, ClearenceType userType);

        string HashToSha1(string password);
    }
}