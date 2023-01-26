using Microsoft.Extensions.Configuration;
using SSCarlJohan.DataManager.Library.Internal.DataAccess;
using SSCarlJohan.DataManager.Library.Internal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSCarlJohan.DataManager.Library.DataAccess
{
    public class UserData
    {
        private readonly IConfiguration config;

        public UserData(IConfiguration config)
        {
            this.config = config;
        }

        public List<UserModel> GetUserById(string Id)
        {
            SqlDataAccess sql = new SqlDataAccess(config);

            var p = new { Id = Id };

            var output = sql.LoadData<UserModel, dynamic>("dbo.spUserLookup", p, "SSCarlJohanConnection");

            return output;
        }
    }
}
