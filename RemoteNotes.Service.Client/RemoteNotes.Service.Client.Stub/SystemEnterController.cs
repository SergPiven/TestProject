using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using RemoteNotes.Service.Domain;
using RemoteNotes.Service.Domain.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteNotes.Service.Client.Stub
{
    public class SystemEnterController
    {
        private CancellationTokenSource cts;
        private ServiceEnvironment serviceEnvironment;
        public SystemEnterController(ServiceEnvironment serviceEnvironment)
        {
            this.serviceEnvironment = serviceEnvironment;
        }
        public UserInfo SystemEnter(string login, string password)
        {
            Task<UserInfo> task = this.SystemEnterAsync(login, password);
            task.Wait();
            UserInfo userInfo = task.Result;
            return userInfo;
        }
        public OperationStatusInfo SystemExit()
        {
            Task<OperationStatusInfo> task = this.SystemExitAsync();
            task.Wait();
            OperationStatusInfo operationStatusInfo = task.Result;
            return operationStatusInfo;
        }
        public async Task<UserInfo> SystemEnterAsync(string login, string password)
        {
            try
            {
                this.cts =
                 new CancellationTokenSource(this.serviceEnvironment.OperationTimeout);
                OperationStatusInfo operationStatusInfo =
                await this.serviceEnvironment.Connection.InvokeCoreAsync<OperationStatusInfo>(
                "enter",
                new object[] { login, password },
                this.cts.Token);
                if (operationStatusInfo.OperationStatus == OperationStatus.Done)
                {
                    string attachedObjectText =
                     operationStatusInfo.AttachedObject.ToString();
                    UserInfo userInfo =
                     JsonConvert.DeserializeObject<UserInfo>(attachedObjectText);
                    return userInfo;
                }
                else
                {
                    throw new Exception(operationStatusInfo.AttachedInfo);
                }
            }
            catch (Exception ex)
            {
                throw new
                 Exception($"Enter operation cannot be performed. {ex.Message}", ex);
            }
        }
        public async Task<OperationStatusInfo> SystemExitAsync()
        {
            try
            {
                this.cts =
                 new CancellationTokenSource(this.serviceEnvironment.OperationTimeout);
                OperationStatusInfo operationStatusInfo =
                 await this.serviceEnvironment.Connection
                 .InvokeAsync<OperationStatusInfo>("exit", this.cts.Token);
                if (operationStatusInfo.OperationStatus == OperationStatus.Done)
                {
                    return operationStatusInfo;
                }
                else
                {
                    throw new Exception(operationStatusInfo.AttachedInfo);
                }
            }
            catch (Exception ex)
            {
                throw new
                 Exception($"Exit operation cannot be performed. {ex.Message}", ex);
            }
        }
    }
}