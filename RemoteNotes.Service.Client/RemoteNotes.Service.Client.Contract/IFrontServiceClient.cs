using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RemoteNotes.Service.Domain;
using RemoteNotes.Service.Domain.Data;

namespace RemoteNotes.Service.Client
{
    public interface IFrontServiceClient
    {
        void Connect(string adress);
        void Disconnect();
        UserInfo Enter(string login, string password);
        OperationStatusInfo Exit();
    }
}
