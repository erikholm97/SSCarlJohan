using Caliburn.Micro;
using SSCarlJohan.Desktop.UI.Library.API;
using SSCarlJohan.Desktop.UI.Library.Models;
using SSCarlJohanDesktop.UI.EventModels;

namespace SSCarlJohanDesktop.UI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private IEventAggregator _events;
        private SalesViewModel _salesVM;
        private ILoggedInUserModel _user;
        private IAPIHelper _apiHelper;

        public ShellViewModel(SalesViewModel salesVM,
                              IEventAggregator events,
                              ILoggedInUserModel user,
                              IAPIHelper apiHelper)
        {
            _events = events;
            _salesVM = salesVM;
            _user = user;
            _apiHelper = apiHelper;
            _events.Subscribe(this);

            ActivateItem(IoC.Get<LoginViewModel>());
        }

        public bool IsLoggedIn
        {
            get 
            { 
                bool output = false;

                if(string.IsNullOrWhiteSpace(_user.Token) == false)
                {
                    output = true;
                }
                
                return output;            
            }
        }

        public void ExitApplication()
        {
            base.TryClose();
        }

        public void LogOut()
        {
            _user.ResetUserModel();
            _apiHelper.LogOffUser();
            ActivateItem(IoC.Get<LoginViewModel>());
            NotifyOfPropertyChange(() => _user);
        }

        public void Handle(LogOnEvent message)
        {
            ActivateItem(_salesVM);
            NotifyOfPropertyChange(() => IsLoggedIn);
        }            
    }
}
