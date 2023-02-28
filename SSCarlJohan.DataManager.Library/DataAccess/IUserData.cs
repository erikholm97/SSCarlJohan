using SSCarlJohan.DataManager.Library.Internal.Models;
using System.Collections.Generic;

namespace SSCarlJohan.DataManager.Library.DataAccess
{
    public interface IUserData
    {
        List<UserModel> GetUserById(string Id);
    }
}