using Microsoft.Extensions.Configuration;
using SSCarlJohan.DataManager.Library.Internal.DataAccess;
using SSCarlJohan.DataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSCarlJohan.DataManager.Library.DataAccess
{
    public class InventoryData : IInventoryData
    {        
        private readonly ISqlDataAccess sql;

        public InventoryData(ISqlDataAccess sql)
        {            
            this.sql = sql;
        }

        public List<InventoryModel> GetInventory()
        {
            var output = sql.LoadData<InventoryModel, dynamic>("dbo.spInventory_GetAll", new { }, "SSCarlJohanConnection");

            return output;
        }

        public void SaveInventoryRecord(InventoryModel item)
        {            
            sql.SaveData("dbo.spInventory_Insert", item, "SSCarlJohanConnection");
        }
    }
}
