using SSCarlJohan.Desktop.UI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSCarlJohan.Desktop.UI.Library.API
{
    public interface IUserEndPoint
    {
        Task<List<UserModel>> GetAll();        
        Task<Dictionary<string, string>> GetAllRoles();
        Task AddUserToRole(string userId, string roleName);
        Task RemoveUserFromRole(string userId, string roleName);
    }
}