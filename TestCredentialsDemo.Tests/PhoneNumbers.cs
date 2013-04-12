using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCredentialsDemo.Tests
{
    [TestClass]
    [DeploymentItem("app.config")]
    public class PhoneNumbers
    {
        const string TEST_ACCOUNTSID = "YOUR_TEST_ACCOUNT_SID";
        const string TEST_AUTHTOKEN = "YOUR_TEST_AUTH_TOKEN";

        const string VALID_AVAILABLE_NUMBER = "+15005550006";
        const string AREA_CODE = "533";

        [TestMethod]
        public void Should_Populate_Customer_PhoneNumber()
        {
            var customer = new Customer(TEST_ACCOUNTSID, TEST_AUTHTOKEN);
            var result = customer.BuyNumber(VALID_AVAILABLE_NUMBER);

            Assert.IsTrue(result);
            Assert.AreEqual(VALID_AVAILABLE_NUMBER, customer.PhoneNumber);
        }

        [TestMethod]
        public void Should_Buy_PhoneNumber_From_NoneAvailable_Area_Code()
        {
            var customer = new Customer(TEST_ACCOUNTSID, TEST_AUTHTOKEN);
            var result = customer.BuyNumberFromAreaCode(AREA_CODE);

            Assert.IsFalse(result);
        }
    }
}
