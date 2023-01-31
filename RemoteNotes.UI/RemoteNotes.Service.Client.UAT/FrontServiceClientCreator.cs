using RemoteNotes.Service.Client.Stub;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteNotes.Service.Client.UAT
{
    class FrontServiceClientCreator
    {
        public static IFrontServiceClient Create()
        {
            return new FrontServiceClient();
        }
    }

}
