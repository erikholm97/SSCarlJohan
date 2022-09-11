﻿using AutoMapper;
using Caliburn.Micro;
using SSCarlJohan.Desktop.UI.Library.API;
using SSCarlJohan.Desktop.UI.Library.Helpers;
using SSCarlJohan.Desktop.UI.Library.Models;
using SSCarlJohanDesktop.UI.Models;
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
        IProductEndPoint _productEndPoint;
        ISaleEndPoint _saleEndPoint;
        IConfigHelper _configHelper;
        IMapper _mapper;

        public SalesViewModel(IProductEndPoint productEndPoint,
            IConfigHelper configHelper,
            ISaleEndPoint saleEndPoint,
            IMapper mapper)
        {
            _productEndPoint = productEndPoint;
            _configHelper = configHelper;
            _saleEndPoint = saleEndPoint;
            _mapper = mapper;
        }        
        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadProducts();
        }

        private async Task LoadProducts()
        {
            var productList = await _productEndPoint.GetAll();
            var products = _mapper.Map<List<ProductDisplayModel>>(productList);
            Products = new BindingList<ProductDisplayModel>(products);
        }

        private BindingList<ProductDisplayModel> _products;

        public BindingList<ProductDisplayModel> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        private ProductDisplayModel _selectedProduct;

        public ProductDisplayModel SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                NotifyOfPropertyChange(() => SelectedProduct);
            }
        }


        private BindingList<CartItemDisplayModel> _cart = new BindingList<CartItemDisplayModel>();

        public BindingList<CartItemDisplayModel> Cart
        {
            get { return _cart; }
            set
            {
                _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }

        private int _itemQuantity = 1;

        public int ItemQuantity
        {
            get { return _itemQuantity; }
            set
            {
                _itemQuantity = value;
                NotifyOfPropertyChange(() => ItemQuantity);
                NotifyOfPropertyChange(() => CanAddToCart);
            }
        }

        public string SubTotal
        {
            get
            {                
                return CalculateSubTotal().ToString("C");
            }
        }

        private decimal CalculateSubTotal()
        {
            decimal subTotal = 0;

            foreach (var item in Cart)
            {
                subTotal += (item.Product.RetailPrice * item.QuantityInCart);
            }

            return subTotal;

        }

        private decimal CalculateTax()
        {
            decimal taxAmount = 0;
            decimal taxeRate = _configHelper.GetTaxRate() / 100;

            taxAmount = Cart
                       .Where(x => x.Product.IsTaxable)
                       .Sum(x => x.Product.RetailPrice * x.QuantityInCart * taxeRate);

            return taxAmount;

        }

        public string Tax
        {
            get
            {                
                return CalculateTax().ToString("C");
            }
        }

        public string Total
        {
            get
            {
                decimal total = CalculateSubTotal() + CalculateTax();

                return total.ToString("C");
            }
        }


        public bool CanAddToCart
        {
            get
            {
                bool output = false;

                if (ItemQuantity > 0 && SelectedProduct?.QuantityInStock >= ItemQuantity)
                {
                    output = true;
                }

                return output;
            }
        }

        public void AddToCart()
        {
            //Compares the objects of product in cart and user selected product. 
            CartItemDisplayModel existingItem = Cart.FirstOrDefault(x => x.Product == SelectedProduct);

            if (existingItem != null)
            {
                existingItem.QuantityInCart += ItemQuantity;
                //Hack for updating the Sales view with correct amount of Quantity without re-adding object. 
                Cart.Remove(existingItem);
                Cart.Add(existingItem);
            }
            else
            {
                CartItemDisplayModel item = new CartItemDisplayModel()
                {
                    Product = SelectedProduct,
                    QuantityInCart = ItemQuantity
                };
                Cart.Add(item);
            }

            SelectedProduct.QuantityInStock -= ItemQuantity;
            ItemQuantity = 1;
            NotifyOfPropertyChange(() => SubTotal);
            NotifyOfPropertyChange(() => Tax);
            NotifyOfPropertyChange(() => Total);
            NotifyOfPropertyChange(() => CanCheckOut);
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
            NotifyOfPropertyChange(() => SubTotal);
            NotifyOfPropertyChange(() => Tax);
            NotifyOfPropertyChange(() => Total);
        }

        public bool CanCheckOut
        {
            get
            {
                bool output = false;

                if(Cart.Count > 0)
                {
                    output = true;
                }

                return output;
            }
        }

        public async Task CheckOut()
        {
            SaleModel sale = new SaleModel();

            foreach (var item in Cart)
            {
                sale.SaleDetails.Add(new SaleDetailModel
                {
                    ProductId = item.Product.Id,
                    Quantity = item.QuantityInCart
                });
            }

            await _saleEndPoint.PostSale(sale);
        }
    }
}
