using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteNotes.UI.Contract
{
    public interface IView
    {
        void SetFocus();
        void ClearError();
        void ShowError(string errorMessage);
    }
}
