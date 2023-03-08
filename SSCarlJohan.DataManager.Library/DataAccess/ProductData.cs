using Microsoft.Extensions.Configuration;
using SSCarlJohan.DataManager.Library.Internal.DataAccess;
using SSCarlJohan.DataManager.Library.Models;
using System.Collections.Generic;
using System.Linq;

namespace SSCarlJohan.DataManager.Library.DataAccess
{
    public class ProductData : IProductData
    {
        private readonly ISqlDataAccess sql;

        public ProductData(ISqlDataAccess sql)
        {
            this.sql = sql;
        }

        public ProductData()
        {
        }
        public List<ProductModel> GetProducts()
        {
            var output = sql.LoadData<ProductModel, dynamic>("dbo.spProduct_GetAll", new { }, "SSCarlJohanConnection");

            return output;
        }

        public ProductModel GetProductById(int productId)
        {
            var output = sql.LoadData<ProductModel, dynamic>("dbo.spProduct_GetById", new { Id = productId }, "SSCarlJohanConnection").FirstOrDefault();

            return output;
        }
    }
}