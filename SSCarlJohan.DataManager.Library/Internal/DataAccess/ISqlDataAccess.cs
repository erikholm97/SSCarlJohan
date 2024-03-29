﻿using System.Collections.Generic;

namespace SSCarlJohan.DataManager.Library.Internal.DataAccess
{
    public interface ISqlDataAccess
    {
        void BeginTransaction(string connectionStringName);
        void CommitTransaction();
        void Dispose();
        string GetConnectionString(string name);
        List<T> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName);
        List<T> LoadDataInTransaction<T, U>(string storedProcedure, U parameters);
        void RollBackTransaction();
        void SaveData<T>(string storedProcedure, T parameters, string connectionStringName);
        void SaveDataInTransaction<T>(string storedProcedure, T parameters);
    }
}