﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using SSCarlJohanDesktop.UI.Helpers;

namespace SSCarlJohanDesktop.UI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _userName;

        private string _password;

        private IAPIHelper _apiHelper;

        public LoginViewModel(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;

                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;

                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public bool CanLogIn
        {
            get
            {
                bool userCanLogIn = false;

                if (UserName?.Length > 0 && Password?.Length > 0)
                {
                    userCanLogIn = true;
                }

                return userCanLogIn;
            }
           
        }

        public async Task LogIn()
        {
            try
            {
                var result = await _apiHelper.Authenticate(UserName, Password);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

    }
}
