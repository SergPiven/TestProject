using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteNotes.UI.Contract
{
    public interface IMainWindowController 
    { 
        void LoadLogin(); 
        void LoadDashboard(); 
        void Exit();
        void RegisterControls(IControlFactory controlFactory);
    }
}
