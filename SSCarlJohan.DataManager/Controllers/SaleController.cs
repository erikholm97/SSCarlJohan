using Microsoft.AspNet.Identity;
using SSCarlJohan.DataManager.Library.DataAccess;
using SSCarlJohan.DataManager.Library.Models;
using SSCarlJohan.DataManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SSCarlJohan.DataManager.Controllers
{
    [Authorize]
    public class SaleController : ApiController
    {
        public void Post(SaleModel sale)
        {
            if (sale == null)
            {
                return;
            }

            SaleData data = new SaleData();

            string userId = RequestContext.Principal.Identity.GetUserId();

            data.SaveSale(sale, userId);

        }

        // GET: api/Product
        //public List<Sale> Get()
        //{
        //    ProductData data = new ProductData();

        //    return data.GetProducts();
        //}
    }
}
