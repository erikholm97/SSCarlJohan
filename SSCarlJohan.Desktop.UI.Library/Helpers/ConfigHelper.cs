using System;
using System.Configuration;

namespace SSCarlJohan.Desktop.UI.Library.Helpers
{
    public class ConfigHelper : IConfigHelper
    {
        public decimal GetTaxRate()
        {
            string rateText = ConfigurationManager.AppSettings["taxRate"];

            bool isValidTaxRate = Decimal.TryParse(rateText, out decimal output);

            if (isValidTaxRate is false)
            {
                throw new ConfigurationErrorsException($"Invalid tax rate. Tax rate was: {rateText}.");
            }

            return output;
        }
    }
}
