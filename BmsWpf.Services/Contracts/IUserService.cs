using BMS.DataBaseModels;
using BmsWpf.Services.DTOs;
using System.Linq;

namespace BmsWpf.Services.Contracts
{
    public interface IUserService
    {
        ClearenceType LoginUser(string username, string password);
        string CreateUser(string username, string password, ClearenceType userType);
        IQueryable<string> GetUsers();
        IQueryable<UserListDto> GetUsernames();

        string HashToSha1(string password);
        string ModifyUser(string username, ClearenceType selectedClearenceType);

        string DeleteUser(string username);
    }
}