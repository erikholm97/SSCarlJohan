using SSCarlJohan.DataManager.Library.Internal.DataAccess;
using SSCarlJohan.DataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSCarlJohan.DataManager.Library.DataAccess
{
    public class SaleData
    {
        public void SaveSale(SaleModel saleInfo, string cashierId)
        {
            //TODO: Make this SOLID/DRY/Better
            // Start filling in the models we will save to the db.
            List<SaleDetailDBModel> details = new List<SaleDetailDBModel>();
            ProductData products = new ProductData();
            var taxRate = ConfigHelper.GetTaxRate();

            foreach (var saleDetail in saleInfo.SaleDetails)
            {
                var detail = new SaleDetailDBModel
                {
                    ProductId = saleDetail.ProductId,
                    Quantity = saleDetail.Quantity,
                };

                // Get the information about this product.
                var productInfo = products.GetProductById(saleDetail.ProductId);

                if (productInfo is null)
                {
                    throw new KeyNotFoundException($"The product Id of { saleDetail.ProductId } could not be found in the database.");
                }

                detail.PurchasePrice = (productInfo.RetailPrice * detail.Quantity);

                if (productInfo.IsTaxable)
                {
                    detail.Tax = (detail.PurchasePrice * taxRate);
                }

                details.Add(detail);
            }

            SaleDBModel sale = new SaleDBModel
            {
                SubTotal = details.Sum(x => x.PurchasePrice),
                Tax = details.Sum(x => x.Tax),
                CashierId = cashierId
            };

            sale.Total = sale.SubTotal + sale.Tax;

            //Save the sale model

            SqlDataAccess sql = new SqlDataAccess();

            sql.SaveData<SaleDBModel>("dbo.spSale_Insert", sale, "SSCarlJohanConnection");

            foreach (var item in details)
            {
                item.SaleId = sale.Id;
                sql.SaveData("dbo.spSaleDetail_Insert", item, "SSCarlJohanConnection");
            }
            
        }
    }
}
