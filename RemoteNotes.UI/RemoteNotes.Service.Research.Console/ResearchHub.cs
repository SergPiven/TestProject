using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RemoteNotes.Service.Research.Console
{
    public class ResearchHub : Hub
    {
        public async Task Send(string message)
        {
            System.Console.Write(message);
            await this.Clients.All.SendAsync("Notify", message);
        }
    }
}
