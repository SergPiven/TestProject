using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteNotes.Service.Client.UAT.Context
{
    public class TestingContext
    {
        private static IFrontServiceClient frontServiceClient;
        static TestingContext()
        {
            frontServiceClient = FrontServiceClientCreator.Create();
        }
        public static IFrontServiceClient GetFrontServiceClient()
        {
            return frontServiceClient;
        }
    }

}
