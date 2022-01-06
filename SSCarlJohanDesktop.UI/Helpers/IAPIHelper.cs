using System.Threading.Tasks;

namespace SSCarlJohanDesktop.UI.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> AuthenticateAsync(string username, string password);
    }
}