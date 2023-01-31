using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteNotes.Service.Research.Client.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            HubConnection connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:61234/notes")
            .Build();
            connection.Closed += async (error) =>
            {
                await connection.StartAsync();
            };
            connection.On<string>("Notify", (message) =>
            {
                System.Console.Write($"Received notification: {message}");
            });
            Task.Run(async () => await ConnectAndSend(connection)).Wait();
            System.Console.ReadKey();
        }
        static async Task ConnectAndSend(HubConnection connection)
        {
            try
            {
                await connection.StartAsync();
                connection.InvokeAsync("Send", "something");
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.Message);
            }
        }
    }
}
