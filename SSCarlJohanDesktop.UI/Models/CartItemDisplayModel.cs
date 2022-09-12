using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSCarlJohanDesktop.UI.Models
{
    public class CartItemDisplayModel : INotifyPropertyChanged
    {

        public ProductDisplayModel Product { get; set; }
        private int _quantityInCart;

        public int QuantityInCart
        {
            get { return _quantityInCart; }
            set
            {
                _quantityInCart = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QuantityInCart)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DisplayText)));
            }
        }


        public string DisplayText
        {
            get => $"{Product.ProductName} ({QuantityInCart}) ({Product.RetailPrice:C} per pc)";
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
