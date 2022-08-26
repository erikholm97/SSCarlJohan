using SSCarlJohan.DataManager.Library.DataAccess;
using SSCarlJohan.DataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SSCarlJohan.DataManager.Controllers
{
    [Authorize]
    public class ProductController : ApiController
    {
        // GET: api/Product
        public List<ProductModel> Get()
        {
            ProductData data = new ProductData();

            return data.GetProducts();
        }
    }
}
