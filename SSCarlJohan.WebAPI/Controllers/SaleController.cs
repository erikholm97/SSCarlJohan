using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SSCarlJohan.DataManager.Library.DataAccess;
using SSCarlJohan.DataManager.Library.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace SSCarlJohan.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SaleController : ControllerBase
    {
        private readonly IConfiguration config;

        public SaleController(IConfiguration config)
        {
            this.config = config;
        }

        [Authorize(Roles = "Cashier")]
        [HttpPost]
        public void Post(SaleModel sale)
        {
            if (sale == null)
            {
                return;
            }

            SaleData data = new SaleData(config);

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier); //RequestContext.Principal.Identity.GetUserId();

            data.SaveSale(sale, userId);

        }

        [Authorize(Roles = "Admin,Manager")]
        [Route("GetSalesReport")]
        [HttpGet]
        public List<SaleReportModel> GetSalesReport()
        {
            SaleData data = new SaleData(config);

            return data.GetSaleReport();
        }
    }
}
