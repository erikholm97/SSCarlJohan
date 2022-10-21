﻿using SSCarlJohan.Desktop.UI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SSCarlJohan.Desktop.UI.Library.API
{
    public class UserEndPoint : IUserEndPoint
    {
        public IAPIHelper _apiHelper;
        public UserEndPoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<UserModel>> GetAll()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/User/Admin/GetAllUsers"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<UserModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase.ToString());
                }
            }
        }
    }
}