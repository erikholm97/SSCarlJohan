using Caliburn.Micro;
using SSCarlJohanDesktop.UI.EventModels;

namespace SSCarlJohanDesktop.UI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {        
        private IEventAggregator _events;
        private SalesViewModel _salesVM;
        private SimpleContainer _container;

        public ShellViewModel(SalesViewModel salesVM, IEventAggregator events, 
            SimpleContainer container)
        {
            _events = events;                        
            _salesVM = salesVM;
            _container = container;

            _events.Subscribe(this);
            
            ActivateItem(_container.GetInstance<LoginViewModel>());
        }

        public void Handle(LogOnEvent message)
            => ActivateItem(_salesVM);            
        
    }
}
