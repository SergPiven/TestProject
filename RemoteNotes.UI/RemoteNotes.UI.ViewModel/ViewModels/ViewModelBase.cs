using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using RemoteNotes.UI.Contract;

namespace RemoteNotes.UI.ViewModel.ViewModels
{
    public abstract class ViewModelBase : DependencyObject, IDataErrorInfo
    {
        protected readonly List<string> validatablePropertyCollection = new List<string>();
        protected IView view;
        protected virtual bool IsValid
        {
            get
            {
                foreach (string property in this.validatablePropertyCollection)
                {
                    if (!string.IsNullOrEmpty(this.GetValidationError(property)))
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        protected abstract string GetValidationError(string property);
        #region IDataErrorInfo
        /// <summary>
        /// The i data error info.this.
        /// </summary>
        /// <param name="property">
        /// The property.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string IDataErrorInfo.this[string property]
        {
            get
            {
                string error = this.GetValidationError(property);
                return error;
            }
        }
        /// <summary>
        /// Gets the error.
        /// </summary>
        string IDataErrorInfo.Error
        {
            get
            {
                return null;
            }
        }
        public IView View
        {
            get { return view; }
            set { view = value; }
        }
        #endregion IDataErrorInfo
 }
}
