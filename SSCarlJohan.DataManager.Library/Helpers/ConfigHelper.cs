using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSCarlJohan.DataManager.Library
{
    public static class ConfigHelper
    {
        public static decimal GetTaxRate()
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
