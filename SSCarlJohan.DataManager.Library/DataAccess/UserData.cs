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
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess sql;

        public UserData(ISqlDataAccess sql)
        {
            this.sql = sql;
        }

        public List<UserModel> GetUserById(string Id)
        {
            var output = sql.LoadData<UserModel, dynamic>("dbo.spUserLookup", new { Id }, "SSCarlJohanConnection");

            return output;
        }
    }
}
