using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RemoteNotes.Service.Domain;
using RemoteNotes.Service.Domain.Data;

namespace RemoteNotes.Service.Client.Stub
{
    public class FrontServiceClient : IFrontServiceClient
    {
        private ServiceEnvironment serviceEnvironment;
        private SystemConnectionController systemConnectionController;
        private SystemEnterController systemEnterController;
        public FrontServiceClient()
        {
            this.ConfigureServiceSettings();
            this.ConfigureOperationControllers(serviceEnvironment);
            Connect("http://localhost:61234");
        }
        private void ConfigureServiceSettings()
        {
            this.serviceEnvironment = new ServiceEnvironment();
            this.serviceEnvironment.HubName = "notes";
            this.serviceEnvironment.ConnectionTimeout = new TimeSpan(0, 1, 0);
        }
        private void ConfigureOperationControllers(ServiceEnvironment serviceEnvironment)
        {
            this.systemConnectionController = new SystemConnectionController(serviceEnvironment);
            this.systemEnterController = new SystemEnterController(serviceEnvironment);
        }
        public async Task ConnectAsync(string address)
        {
            await this.systemConnectionController.ConnectAsync(address);
        }
        public void Connect(string address)
        {
            this.systemConnectionController.Connect(address);
        }
        public void Disconnect()
        {
            this.systemConnectionController.Disconnect();
        }
        public UserInfo Enter(string login, string password)
        {
            return this.systemEnterController.SystemEnter(login, password);
        }
        public OperationStatusInfo Exit()
        {
            return this.systemEnterController.SystemExit();
        }
        public async Task<OperationStatusInfo> ExitAsync()
        {
            return await this.systemEnterController.SystemExitAsync();
        }
        public async Task<UserInfo> EnterAsync(string login, string password)
        {
            return await this.systemEnterController.SystemEnterAsync(login, password);
        }
    }
}
