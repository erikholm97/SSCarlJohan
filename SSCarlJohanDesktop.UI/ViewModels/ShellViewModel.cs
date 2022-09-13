using Caliburn.Micro;
using SSCarlJohanDesktop.UI.EventModels;

namespace SSCarlJohanDesktop.UI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {        
        private IEventAggregator _events;
        private SalesViewModel _salesVM;        

        public ShellViewModel(SalesViewModel salesVM, IEventAggregator events)
        {
            _events = events;                        
            _salesVM = salesVM;            
            _events.Subscribe(this);
            
            ActivateItem(IoC.Get<LoginViewModel>());
        }

        public void ExitApplication()
        {
            base.TryClose();
        }

        public void LogOut()
        {

        }

        public void Handle(LogOnEvent message)
            => ActivateItem(_salesVM);            
        
    }
}
