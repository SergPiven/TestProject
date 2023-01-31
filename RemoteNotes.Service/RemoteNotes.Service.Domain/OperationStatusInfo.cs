using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteNotes.Service.Domain
{
    public class OperationStatusInfo
    {
        public OperationStatus OperationStatus { set; get; }
        public string AttachedInfo { set; get; }
        public object AttachedObject { set; get; }

        public OperationStatusInfo(OperationStatus operationStatus) 
        {
            OperationStatus = operationStatus;
        }
    }
    public enum OperationStatus 
    {
        Done,
        Cancelled
    }
}
