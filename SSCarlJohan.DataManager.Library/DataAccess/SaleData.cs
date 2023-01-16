using Microsoft.Extensions.Configuration;
using SSCarlJohan.DataManager.Library.Helpers;
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
        private readonly IConfiguration config;

        public SaleData(IConfiguration config)
        {
            this.config = config;
        }

        public SaleData()
        {
        }
        public void SaveSale(SaleModel saleInfo, string cashierId)
        {
            //TODO: Make this SOLID/DRY/Better
            // Start filling in the models we will save to the db.
            List<SaleDetailDBModel> details = new List<SaleDetailDBModel>();
            ProductData products = new ProductData(config);
            var taxRate = ConfigHelper.GetTaxRate() / 100;

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
            using (SqlDataAccess sql = new SqlDataAccess(config))
            {
                try
                {
                    sql.BeginTransaction("SSCarlJohanConnection");

                    // Save the sale model.
                    sql.SaveDataInTransaction("dbo.spSale_Insert", sale);

                    // GET THE ID FROM SALE MODEL.
                    sale.Id = sql.LoadDataInTransaction<int, dynamic>("spSale_Lookup", new { sale.CashierId, sale.SaleDate }).FirstOrDefault();

                    foreach (var item in details)
                    {
                        item.SaleId = sale.Id;
                        sql.SaveDataInTransaction("dbo.spSaleDetail_Insert", item);
                    }

                    sql.CommitTransaction();
                }
                catch
                {
                    sql.RollBackTransaction();
                    throw;
                }             
            }
        }

        public List<SaleReportModel> GetSaleReport()
        {
            SqlDataAccess sql = new SqlDataAccess(config);

            var output = sql.LoadData<SaleReportModel, dynamic>("dbo.spSale_SaleReport", new { }, "SSCarlJohanConnection");

            return output;
        }
    }
}
