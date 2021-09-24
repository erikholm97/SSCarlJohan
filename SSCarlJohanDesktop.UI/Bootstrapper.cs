using Caliburn.Micro;
using SSCarlJohanDesktop.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SSCarlJohanDesktop.UI
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
