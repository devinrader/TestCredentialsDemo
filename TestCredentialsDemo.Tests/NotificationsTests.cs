using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCredentialsDemo.Tests
{
    [TestClass]
    [DeploymentItem("app.config")]
    public class NotificationsTests
    {
        const string TEST_ACCOUNTSID = "YOUR_TEST_ACCOUNT_SID";
        const string TEST_AUTHTOKEN = "YOUR_TEST_AUTH_TOKEN";

        const string TO_NUMBER = "+15005550006";
        const string NONMOBILE_FAIL_TO_NUMBER = "+15005550009";
        const string NONOWNED_FROM_NUMBER = "+15005550007";
        const string INTERNATIONAL_FAIL_TO_NUMBER = "+15005550003";

        [TestMethod]
        public void Should_Send_Sms_Message_Successfully()
        {
            var message = Notifications.CreateMessage(TO_NUMBER);
            message.Send(TEST_ACCOUNTSID, TEST_AUTHTOKEN);

            Assert.AreEqual(MessageStatus.Success, message.Status);
        }

        [TestMethod]
        public void Should_Not_Send_Sms_Message_To_Nonmobile_Number()
        {
            var message = Notifications.CreateMessage(NONMOBILE_FAIL_TO_NUMBER);
            message.Send(TEST_ACCOUNTSID, TEST_AUTHTOKEN);

            Assert.AreEqual(MessageStatus.Fail, message.Status);
        }

        [TestMethod]
        public void Should_Not_Send_Sms_Message_From_Nonowned_Number()
        {
            var message = Notifications.CreateMessage(NONOWNED_FROM_NUMBER, TO_NUMBER);
            message.Send(TEST_ACCOUNTSID, TEST_AUTHTOKEN);

            Assert.AreEqual(MessageStatus.Fail, message.Status);
        }

        [TestMethod]
        public void Should_Initiate_Outbound_Call_Successfully()
        {
            var call = Notifications.CreateCall(TO_NUMBER);
            call.Initiate(TEST_ACCOUNTSID, TEST_AUTHTOKEN);
 
            Assert.AreEqual(CallStatus.Success, call.Status);
        }

        [TestMethod]
        public void Should_Not_Initiate_Outbound_Call_To_International_Number()
        {
            var call = Notifications.CreateCall(INTERNATIONAL_FAIL_TO_NUMBER);
            call.Initiate(TEST_ACCOUNTSID, TEST_AUTHTOKEN);
 
            Assert.AreEqual(CallStatus.Fail, call.Status);
        }
    }
}
