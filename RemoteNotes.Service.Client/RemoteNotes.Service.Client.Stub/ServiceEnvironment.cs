using Microsoft.AspNetCore.SignalR.Client;
using System;

namespace RemoteNotes.Service.Client.Stub
{
    public class ServiceEnvironment
    {
        public string HubName { get; set; } = "notes";
        public TimeSpan ConnectionTimeout { get; set; } = new TimeSpan(0, 0, 30);
        public TimeSpan OperationTimeout { get; set; } = new TimeSpan(0, 0, 30);
        public HubConnection Connection { get; set; }

    }
}