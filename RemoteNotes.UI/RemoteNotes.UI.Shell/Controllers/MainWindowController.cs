using RemoteNotes.UI.Control.Controls;
using RemoteNotes.UI.Shell.Infrastracture;
using RemoteNotes.UI.Shell.Managers;
using RemoteNotes.UI.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RemoteNotes.UI.Shell.Controllers
{
    public class MainWindowController : IMainWindowController
    {
        private MainWindow mainWindow;
        private ControlManager controlManager;
        private IApplication application;

        public MainWindowController(IApplication application)
        {
            this.application = application;
            this.mainWindow = new MainWindow();
            this.controlManager = new ControlManager();
        }
        public void RegisterControls(IControlFactory controlFactory)
        {
            this.controlManager.Register("MainWindow", mainWindow);
            this.controlManager.Register("LoginControl", controlFactory.Create<LoginControl>());
            this.controlManager.Register("DashboardControl", controlFactory.Create<DashboardControl>());
        }
        public void LoadLogin()
        {
            #region Main window definition
            mainWindow.WindowStyle = WindowStyle.None;
            mainWindow.WindowState = WindowState.Normal;
            this.mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.mainWindow.Show();
            #endregion
            controlManager.Place("MainWindow", "MainRegion", "LoginControl");
        }
        public void Exit()
        {
            this.application.Exit();
        }
        public void LoadDashboard()
        {
            Window mainWindow = this.controlManager.GetControl("MainWindow") as Window;
            mainWindow.WindowState = WindowState.Maximized;
            mainWindow.WindowStyle = WindowStyle.SingleBorderWindow;
            this.controlManager.Place("MainWindow", "MainRegion", "DashboardControl");
        }
    }
}
