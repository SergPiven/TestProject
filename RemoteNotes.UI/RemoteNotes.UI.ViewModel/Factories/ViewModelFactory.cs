using RemoteNotes.UI.Contract;
using RemoteNotes.UI.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using RemoteNotes.Service.Client;
using RemoteNotes.Rules.Contract;

namespace RemoteNotes.UI.ViewModel.Factories
{
    public class ViewModelFactory : IViewModelFactory
    {
        readonly Dictionary<Type, object> viewModelCollection = new Dictionary<Type,object>();
        public ViewModelFactory(IMainWindowController mainWindowController,
            IFrontServiceClient frontServiceClient, IValidationRuleFactory validationRuleFactory)
        {
            this.viewModelCollection.Add(typeof(LoginViewModel),
            new LoginViewModel( mainWindowController, frontServiceClient,
                validationRuleFactory.Create<IEnterOperationValidationRule>()));
            this.viewModelCollection.Add(typeof(DashboardViewModel), new
           DashboardViewModel());
        }
        public T Create<T>()
        {
            Type type = typeof(T);
            if (!this.viewModelCollection.ContainsKey(type))
            {
                throw new MissingMemberException(type.ToString() + "is missing in the view model collection");
            }
            return (T)this.viewModelCollection[type];
        }
    }

}
