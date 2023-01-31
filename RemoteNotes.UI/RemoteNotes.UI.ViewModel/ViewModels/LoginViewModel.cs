using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using RemoteNotes.Rules.Contract;
using RemoteNotes.UI.Contract;
using RemoteNotes.Service.Client;
using RemoteNotes.Service.Domain.Data;
using Common.UI.Utility;

namespace RemoteNotes.UI.ViewModel.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public string Password
        {
            get { return (string)this.GetValue(PasswordProperty); }
            set { this.SetValue(PasswordProperty, value); }
        }
        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register("Password", typeof(string),
       typeof(LoginViewModel), new PropertyMetadata(null));
        public string Login
        {
            get { return (string)this.GetValue(LoginProperty); }
            set { this.SetValue(LoginProperty, value); }
        }
        public static readonly DependencyProperty LoginProperty = DependencyProperty.Register("Login", typeof(string),
            typeof(LoginViewModel), new PropertyMetadata(null));

        private IEnterOperationValidationRule enterOperationValidationRule;
        private IMainWindowController mainWindowController;
        private IFrontServiceClient frontServiceClient;

        public LoginViewModel(IMainWindowController mainWindowController, IFrontServiceClient frontServiceClient,
            IEnterOperationValidationRule enterOperationValidationRule)
        {
            this.mainWindowController = mainWindowController;
            this.frontServiceClient = frontServiceClient;
            this.validatablePropertyCollection.Add("Login");
            this.validatablePropertyCollection.Add("Password");
            this.enterOperationValidationRule = enterOperationValidationRule;
        }
        #region LoginCommand
        private RelayCommand enterCommand;
        private RelayCommand exitCommand;
        public ICommand EnterCommand
        {
            get
            {
                if (this.enterCommand == null)
                {
                    this.enterCommand = new RelayCommand(param =>
                   this.Enter(), param => this.CanEnter);
                }

                return this.enterCommand;
            }
        }
        public ICommand ExitCommand
        {
            get
            {
                if (this.exitCommand == null)
                {
                    this.enterCommand = new RelayCommand(param =>
                   this.Exit(), null);
                }
                return this.enterCommand;
            }
        }
        private bool CanEnter
        {
            get
            {
                return this.IsValid;
            }
        }
        private void Enter()
        {
            this.view.ClearError();
            string login = Login;
            string password = Password;
            Task.Run(() =>
            {
                try
                {
                    UserInfo userInfo = this.frontServiceClient.Enter(login, password);
                    Dispatcher.Invoke(() =>
                    {
                        this.mainWindowController.LoadDashboard();
                    });
                }
                catch (Exception ex)
                {
                    Dispatcher.Invoke(() =>
                    {
                        this.view.ShowError(ex.Message);
                        this.view.SetFocus();
                    });
                }
            });
        }
        private void Exit()
        {
            try
            {
                this.view.ClearError();
                frontServiceClient.Disconnect();
                this.mainWindowController.Exit();
            }
            catch (Exception ex)
            {
                this.view.ShowError(ex.Message);
                this.view.SetFocus();
            }
        }
        #endregion
        #region Validation
        /// <summary>
        /// The get validation error.
        /// </summary>
        /// <param name="property">
        /// The property.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        protected override string GetValidationError(string property)
        {
            string error = null;
            switch (property)
            {
                case "Login":
                    error =
                   this.enterOperationValidationRule.ValidateLogin(this.Login).GetErrorMessage();
                    break;
                case "Password":
                    error =
                   this.enterOperationValidationRule.ValidatePassword(this.Password).GetErrorMessage();
                    break;
                default:
                    break;
            }
            return error;
        }
        #endregion Validation
    }
}
