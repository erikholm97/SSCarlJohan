using Caliburn.Micro;
using SSCarlJohan.Desktop.UI.Library.Models;
using SSCarlJohanDesktop.UI.EventModels;

namespace SSCarlJohanDesktop.UI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private IEventAggregator _events;
        private SalesViewModel _salesVM;
        private ILoggedInUserModel _user;

        public ShellViewModel(SalesViewModel salesVM,
            IEventAggregator events,
            ILoggedInUserModel user)
        {
            _events = events;
            _salesVM = salesVM;
            _user = user;
            _events.Subscribe(this);

            ActivateItem(IoC.Get<LoginViewModel>());
        }

        public bool IsAccountVisible
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
            _user.LogOffUser();
        }

        public void Handle(LogOnEvent message)
        {
            ActivateItem(_salesVM);
            NotifyOfPropertyChange(() => IsAccountVisible);
        }            
    }
}
