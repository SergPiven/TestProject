using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteNotes.Service.Client.Stub
{
    class SystemConnectionController
    {
        private HubConnection hubConnection;
        private ServiceEnvironment serviceEnvironment;
        private CancellationTokenSource cts;
        public SystemConnectionController(ServiceEnvironment serviceSettings)
        {
            this.serviceEnvironment = serviceSettings;
        }
        public async void Connect(string serviceUrl)
        {
            await this.ConnectAsync(serviceUrl);
        }
        public async Task ConnectAsync(string serviceUrl)
        {
            try
            {
                string hubName = this.serviceEnvironment.HubName;
                string servicePathUrl = $"{serviceUrl}/{hubName}";
                this.hubConnection = new HubConnectionBuilder().WithUrl(servicePathUrl).Build();
                this.serviceEnvironment.Connection = hubConnection;
                hubConnection.Closed += this.HubConnectionOnClosed;
                Console.WriteLine(serviceEnvironment.Connection.ToString());
                this.cts =
                 new CancellationTokenSource(this.serviceEnvironment.ConnectionTimeout);
                await hubConnection.StartAsync(this.cts.Token);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task HubConnectionOnClosed(Exception arg)
        {
            await this.hubConnection.StartAsync();
        }
        public async void Disconnect()
        {
            if (this.hubConnection != null)
            {
                if (this.hubConnection.State != HubConnectionState.Disconnected)
                {
                    await this.hubConnection.StopAsync();
                }
            }
        }
    }
}