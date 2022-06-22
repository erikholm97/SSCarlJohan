using System;
using System.Configuration;

namespace SSCarlJohan.Desktop.UI.Library.Helpers
{
    public class ConfigHelper : IConfigHelper
    {
        public double GetTaxRate()
        {
            string rateText = ConfigurationManager.AppSettings["taxRate"];

            bool isValidTaxRate = Double.TryParse(rateText, out double output);

            if (isValidTaxRate is false)
            {
                throw new ConfigurationErrorsException($"Invalid tax rate. Tax rate was: {rateText}.");
            }

            return output;
        }
    }
}
