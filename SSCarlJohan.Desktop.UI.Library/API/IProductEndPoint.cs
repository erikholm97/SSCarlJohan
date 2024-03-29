﻿using SSCarlJohan.Desktop.UI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSCarlJohan.Desktop.UI.Library.API
{
    public interface IProductEndPoint
    {
        Task<List<ProductModel>> GetAll();
    }
}