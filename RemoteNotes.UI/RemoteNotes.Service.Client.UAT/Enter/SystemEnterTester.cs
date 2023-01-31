using RemoteNotes.Service.Domain;
using RemoteNotes.Service.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace RemoteNotes.Service.Client.UAT.Enter
{
    [Binding]
    public partial class SystemEnterTester : TesterBase
    {
        private UserInfo userInfo;
        /// <summary>
        /// The enter the system.
        /// </summary>
        /// <param name="login">
        /// The login.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        [When("I enter the login: (.*) and password: (.*)")]
        public void EnterTheSystem(string login, string password)
        {
            this.userInfo = this.frontServiceClient.Enter(login, password);
            Thread.Sleep(100);
        }
        /// <summary>
        /// The exit the system.
        /// </summary>
        /// <exception cref="Exception">
        /// </exception>
        [When("I try to exit the system")]
        public void ExitTheSystem()
        {
            OperationStatusInfo result = this.frontServiceClient.Exit();
            Thread.Sleep(100);
            if (result.OperationStatus != OperationStatus.Done)
            {
                throw new Exception("Exit is not ok.");
            }
        }
    }
}
