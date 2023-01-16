using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SSCarlJohan.DataManager.Library.DataAccess;
using SSCarlJohan.DataManager.Library.Models;
using System.Collections.Generic;

namespace SSCarlJohan.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InventoryController : ControllerBase
    {
        private readonly IConfiguration config;

        public InventoryController(IConfiguration config)
        {
            this.config = config;
        }

        [Authorize(Roles = "Manager,Admin")]
        public List<InventoryModel> Get()
        {
            InventoryData data = new InventoryData(config);
            return data.GetInventory();
        }

        [Authorize(Roles = "Admin")]
        public void Post(InventoryModel item)
        {
            InventoryData data = new InventoryData(config);
            data.SaveInventoryRecord(item);
        }
    }
}
