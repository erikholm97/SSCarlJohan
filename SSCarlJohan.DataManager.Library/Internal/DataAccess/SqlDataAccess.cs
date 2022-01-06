using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSCarlJohan.DataManager.Library.Internal.DataAccess
{
    internal class SqlDataAccess //https://youtu.be/k6mbESq--eE?t=1359
    {
        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public List<T> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName)
        {
            string connectionString = GetConnectionString(storedProcedure);

            using (IDbConnection connection = new SqlConnection())
            {
                List<T> rows = connection.Query<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).ToList();

                return rows;
            }
        }

        public void SaveData<T>(string storedProcedure, T parameters, string connectionStringName)
        {
            string connectionString = GetConnectionString(storedProcedure);

            using (IDbConnection connection = new SqlConnection())
            {
                connection.Execute(storedProcedure, parameters,
                                   commandType: CommandType.StoredProcedure);
            }
        }
    }
}
