using RemoteNotes.Service.Client.UAT.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteNotes.Service.Client.UAT
{
    public class TesterBase
    {
        protected IFrontServiceClient frontServiceClient;
        protected Exception lastException;
        public TesterBase()
        {
            this.frontServiceClient = TestingContext.GetFrontServiceClient();
        }
    }

}
