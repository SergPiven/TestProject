using Microsoft.AspNetCore.SignalR;
using RemoteNotes.Service.Domain;
using RemoteNotes.Service.Domain.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RemoteNotes.Service.Console
{
    public partial class MainHub : Hub
    {
        protected readonly static List<string> connectionCollection = new List<string>();
        protected static readonly object locker = new object();
        private HubEnvironment hubEnvironment;
        public MainHub(HubEnvironment hubEnvironment)
        {
            this.hubEnvironment = hubEnvironment;
        }
        protected virtual bool IsUserEntered
        {
            get
            {
                return connectionCollection.Contains(this.Context.ConnectionId);
            }
        }
        protected void AddConnection(string connectionId)
        {
            lock (locker)
            {
                if (!connectionCollection.Contains(connectionId))
                {
                    connectionCollection.Add(connectionId);
                }
            }
        }
        protected void RemoveConnection(string connectionId)
        {
            lock (locker)
            {
                if (connectionCollection.Contains(connectionId))
                {
                    connectionCollection.Remove(connectionId);
                }
            }
        }
        protected void JoinGroup(string groupName)
        {
            this.Groups.AddToGroupAsync(this.Context.ConnectionId, groupName);
        }
        protected void LeaveGroup(string groupName)
        {
            this.Groups.RemoveFromGroupAsync(this.Context.ConnectionId, groupName);
        }
        protected string GetIpAddress()
        {
            var ipAddress =
             Context.GetHttpContext().Connection.RemoteIpAddress.ToString();
            return ipAddress;
        }
    }
    partial class MainHub
    {
        public virtual async Task<OperationStatusInfo> Enter(string login, string password)
        {
            var connectionId = this.Context.ConnectionId;
            return await Task.Run(
            async () =>
            {
                string clientIp = this.GetIpAddress();
                OperationStatusInfo operationStatusInfo = new OperationStatusInfo(OperationStatus.Done);
                try
                {
                    UserInfo userInfo =
                        await this.hubEnvironment.userController.GetUserInfoAsync(login);
                    operationStatusInfo.AttachedObject = userInfo;
                    this.AddConnection(connectionId);
                    this.JoinGroup("shouldBeNotified");
                    return operationStatusInfo;
                }
                catch (Exception ex)
                {
                    operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
                    operationStatusInfo.AttachedInfo = "User is not defined. Check your login and password.";
                }
                return operationStatusInfo;
            });
        }

        public async Task<OperationStatusInfo> Exit()
        {
            var connectionId = this.Context.ConnectionId;
            return await Task.Run(
            () =>
            {
                OperationStatusInfo operationStatusInfo =
     new OperationStatusInfo(OperationStatus.Done);
                string clientIp = this.GetIpAddress();
                try
                {
                    if (this.IsUserEntered)
                    {
                        operationStatusInfo.OperationStatus = OperationStatus.Done;
                        this.RemoveConnection(connectionId);
                        this.LeaveGroup("shouldBeNotified");
                    }
                    else
                    {
                        operationStatusInfo.OperationStatus =
             OperationStatus.Cancelled;
                        operationStatusInfo.AttachedInfo = "User is not entered";
                    }
                }
                catch (Exception ex)
                {
                    operationStatusInfo.OperationStatus = OperationStatus.Cancelled;
                    operationStatusInfo.AttachedInfo = ex.Message;
                }
                return operationStatusInfo;
            });
        }
    }
}