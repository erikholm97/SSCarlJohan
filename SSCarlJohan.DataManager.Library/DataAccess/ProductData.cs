using SSCarlJohan.DataManager.Library.Internal.DataAccess;
using SSCarlJohan.DataManager.Library.Models;
using System.Collections.Generic;
using System.Linq;

namespace SSCarlJohan.DataManager.Library.DataAccess
{
    public class ProductData
    {
        public List<ProductModel> GetProducts()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var output = sql.LoadData<ProductModel, dynamic>("dbo.spProduct_GetAll", new { }, "SSCarlJohanConnection");

            return output;
        }

        public ProductModel GetProductById(int productId)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var output = sql.LoadData<ProductModel, dynamic>("dbo.spProduct_GetById", new { Id = productId }, "SSCarlJohanConnection").FirstOrDefault();

            return output;
        }
    }
}