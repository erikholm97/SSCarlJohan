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
    [Authorize(Roles = "Cashier,Manager,Admin")]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration config;

        public ProductController(IConfiguration config)
        {
            this.config = config;
        }

        // GET: api/Product
        public List<ProductModel> Get()
        {
            ProductData data = new ProductData(config);

            return data.GetProducts();
        }
    }
}
