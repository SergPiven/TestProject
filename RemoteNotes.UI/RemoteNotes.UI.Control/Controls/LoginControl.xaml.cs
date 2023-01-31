using RemoteNotes.UI.Contract;
using RemoteNotes.UI.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using Common.UI.Utility;

namespace RemoteNotes.UI.Control.Controls
{
    /// <summary>
    /// Логика взаимодействия для LoginControl.xaml
    /// </summary>
    public partial class LoginControl : UserControl, IView
    {
        public LoginViewModel LoginViewModel
        {
            get { return (LoginViewModel)this.GetValue(LoginViewModelProperty); }
            set { this.SetValue(LoginViewModelProperty, value); }
        }

        public static readonly DependencyProperty LoginViewModelProperty =
       DependencyProperty.Register("LoginViewModel", typeof(LoginViewModel),
        typeof(LoginControl), new UIPropertyMetadata(null));

        public LoginControl(LoginViewModel loginViewModel)
        {
            loginViewModel.View = this;
            InitializeComponent();
            this.LoginViewModel = loginViewModel;
            this.DataContext = this.LoginViewModel;
        }
        public void ShowError(string error)
        {
            this.txtError.Content = error.Trim();
        }
        public void SetFocus()
        {
            FocusManager.SetFocusedElement(this, this.txtLogin);
        }
        public void ClearError()
        {
            this.txtError.Content = "";
        }
    }
}
