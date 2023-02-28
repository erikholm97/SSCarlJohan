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
        private readonly IProductData productData;

        public ProductController(IConfiguration config, IProductData productData)
        {
            this.config = config;
            this.productData = productData;
        }

        // GET: api/Product
        [HttpGet]
        public List<ProductModel> Get()
        {
            return productData.GetProducts();
        }
    }
}
