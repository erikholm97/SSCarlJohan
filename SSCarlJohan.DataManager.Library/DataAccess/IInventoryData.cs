﻿using SSCarlJohan.DataManager.Library.Models;
using System.Collections.Generic;

namespace SSCarlJohan.DataManager.Library.DataAccess
{
    public interface IInventoryData
    {
        List<InventoryModel> GetInventory();
        void SaveInventoryRecord(InventoryModel item);
    }
}