using NUnit.Framework;
using RemoteNotes.Service.Client.UAT.Context;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using TechTalk.SpecFlow;

namespace RemoteNotes.Service.Client.UAT.Connect
{
    [Binding]
    public partial class ConnectTester : TesterBase
    {
        /// <summary>
        /// The connect the service.
        /// </summary>
        [Given("I try to connect to the service")]
        [When("I try to connect to the service")]
        public void ConnectTheService()
        {
            string serviceUrl = "http://localhost:61234";//ConfigurationManager.AppSettings["ServiceUrl"];
            this.frontServiceClient.Connect(serviceUrl);
        }
        /// <summary>
        /// The disconnect from the service.
        /// </summary>
        [Given("I try to disconnect from the service")]
        [When("I try to disconnect from the service")]
        public void DisconnectFromTheService()
        {
            this.frontServiceClient.Disconnect();
        }
        /// <summary>
        /// The connect wrong service.
        /// </summary>
        [Given("I try to connect to wrong service")]
        [When("I try to connect to wrong service")]
        public void ConnectWrongService()
        {
            try
            {
                string serviceUrl = "http://localhost:61234x";
                 //ConfigurationManager.AppSettings["ServiceUrl"] + "x";
                TestingContext.GetFrontServiceClient().Connect(serviceUrl);
            }
            catch (Exception ex)
            {
                this.lastException = ex;
            }
        }
        /// <summary>
        /// The result successful.
        /// </summary>
        [When("the result should be connected successfully")]
        [Then("the result should be connected successfully")]
        public void ConnectResultSuccessful()
        {
            Assert.That(this.lastException == null);
        }
        /// <summary>
        /// The disconnect result successful.
        /// </summary>
        [When("the result should be disconnected successfully")]
        [Then("the result should be disconnected successfully")]
        public void DisconnectResultSuccessful()
        {
            Assert.That(this.lastException == null);
        }
        /// <summary>
        /// The result failed.
        /// </summary>
        [Then("the result should be failed to connect")]
        public void ResultFailed()
        {
            Assert.That(this.lastException != null);
        }
    }
}
