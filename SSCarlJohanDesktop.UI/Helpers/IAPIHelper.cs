using SSCarlJohanDesktop.UI.ViewModels;
using System.Threading.Tasks;

namespace SSCarlJohanDesktop.UI.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
    }
}