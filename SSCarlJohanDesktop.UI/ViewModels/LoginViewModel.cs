using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using SSCarlJohan.Desktop.UI.Library.API;
using SSCarlJohanDesktop.UI.EventModels;
using SSCarlJohanDesktop.UI.Helpers;

namespace SSCarlJohanDesktop.UI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _userName;

        private string _password;

        private IAPIHelper _apiHelper;

        private IEventAggregator _events;

        public LoginViewModel(IAPIHelper apiHelper, IEventAggregator events)
        {
            _apiHelper = apiHelper;
            _events = events;
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
        
        public bool IsErrorVisible
        {
            get 
            {
                bool output = false;

                if(ErrorMessage?.Length > 0)
                {
                    output = true;
                }

                return output;
            }
        }

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set 
            {                
                _errorMessage = value;
                NotifyOfPropertyChange(() => IsErrorVisible);
                NotifyOfPropertyChange(() => ErrorMessage);
            }
        }


        public async Task LogIn()
        {
            try
            {
                ErrorMessage = "";
                var result = await _apiHelper.AuthenticateAsync(UserName, Password);

                await _apiHelper.GetLoggedInUserInfo(result.Access_Token);

                _events.PublishOnUIThread(new LogOnEvent());
            }
            catch(Exception ex)
            {
                ErrorMessage = ex.Message;
            }            
        }

    }
}
