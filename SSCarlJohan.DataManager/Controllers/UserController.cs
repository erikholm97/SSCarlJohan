using Microsoft.AspNet.Identity;
using SSCarlJohan.DataManager.Library.DataAccess;
using SSCarlJohan.DataManager.Library.Internal.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace SSCarlJohan.DataManager.Controllers
{
    [Authorize]
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        public List<UserModel> GetById()
        {
            string userId = RequestContext.Principal.Identity.GetUserId();

            UserData userData = new UserData();

            return userData.GetUserById(userId);
        }
    }
}
