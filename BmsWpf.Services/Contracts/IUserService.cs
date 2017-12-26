using BMS.DataBaseModels;

namespace BmsWpf.Services.Contracts
{
    public interface IUserService
    {
        User LoginUser(string username, string password);
    }
}