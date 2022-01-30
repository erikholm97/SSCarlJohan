using SSCarlJohan.Desktop.UI.Library.Models;
using System.Threading.Tasks;

namespace SSCarlJohan.Desktop.UI.Library.API
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> AuthenticateAsync(string username, string password);
        Task<LoggedInUserModel> GetLoggedInUserInfo(string token);
    }
}