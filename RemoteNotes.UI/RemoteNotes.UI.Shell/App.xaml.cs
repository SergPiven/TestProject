using RemoteNotes.UI.Shell.Controllers;
using RemoteNotes.UI.Shell.Infrastracture;
using RemoteNotes.UI.ViewModel.Factories;
using RemoteNotes.UI.Control.Factories;
using System;
using System.Windows;
using RemoteNotes.UI.Contract;
using RemoteNotes.Service.Client;
using RemoteNotes.Service.Client.Stub;
using RemoteNotes.Rules.Factories;
using RemoteNotes.Rules.Contract;
namespace RemoteNotes.UI.Shell
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application, IApplication
    {
        private void AppStartUp(object sender, StartupEventArgs args)
        {
            try
            {
                IMainWindowController mainWindowController = new MainWindowController(this);

                IFrontServiceClient frontServiceClient = new FrontServiceClient();
                IValidationRuleFactory validationRuleFactory = new ValidationRuleFactory();

                IViewModelFactory viewModelFactory = new ViewModelFactory(mainWindowController,
                 frontServiceClient, validationRuleFactory);

                IControlFactory controlFactory = new ControlFactory(viewModelFactory);
                mainWindowController.RegisterControls(controlFactory);
                mainWindowController.LoadLogin();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private void AppExit(object sender, ExitEventArgs args)
        {
            this.Shutdown();
        }
        void IApplication.Exit()
        {
            Shutdown();
        }
    }
}
