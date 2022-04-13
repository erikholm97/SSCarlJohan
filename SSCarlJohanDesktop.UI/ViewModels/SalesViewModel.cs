using Caliburn.Micro;
using SSCarlJohan.Desktop.UI.Library.API;
using SSCarlJohan.Desktop.UI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSCarlJohanDesktop.UI.ViewModels
{
    public class SalesViewModel : Screen
    {
        private IProductEndPoint productEndPoint;

        public SalesViewModel(IProductEndPoint productEndPoint)
        {
            this.productEndPoint = productEndPoint;
            LoadProducts();
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            LoadProducts();
        }

        private async Task LoadProducts()
        {
            var products = await productEndPoint.GetAll();
            Products = new BindingList<ProductModel>(products);
        }

        private BindingList<ProductModel> _products;

        public BindingList<ProductModel> Products
        {
            get { return _products; }
            set 
            {                
                _products = value; 
                NotifyOfPropertyChange(() => Products);
            }
        }

        private BindingList<string> _cart;

        public BindingList<string> Cart
        {
            get { return _cart; }
            set
            {
                _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }

        private int _itemQuantity;

        public int ItemQuantity
        {
            get { return _itemQuantity; }
            set 
            { 
                _itemQuantity = value;
                NotifyOfPropertyChange(() => ItemQuantity);
            }
        }

        public string SubTotal
        {
            get
            {
                return "0.00 KR";
            }
        }

        public string Tax
        {
            get
            {
                return "0.00 KR";
            }
        }

        public string Total
        {
            get
            {
                return "0.00 KR";
            }
        }


        public bool CanAddToCart
        {
            get
            {
                bool output = false;


                //Make sure something is selected
                // Make sure there is an item quantity.

                return output;
            }
        }

        public void AddToCart()
        {
        
        }

        public bool CanRemoveFromCart
        {
            get
            {
                bool output = false;


                //Make sure something is selected
                // Make sure there is an item quantity.

                return output;
            }
        }

        public void RemoveFromCart()
        {

        }

        public bool CanCheckOut
        {
            get
            {
                bool output = false;


                //Make sure something is selected
                // Make sure there is an item quantity.

                return output;
            }
        }

        public void CheckOut()
        {

        }
    }
}
