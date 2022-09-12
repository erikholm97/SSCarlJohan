using SSCarlJohan.Desktop.UI.Library.Models;
using System.Threading.Tasks;

namespace SSCarlJohan.Desktop.UI.Library.API
{
    public interface ISaleEndPoint
    {
        Task PostSale(SaleModel sale);
    }
}