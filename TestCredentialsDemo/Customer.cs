using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;

namespace TestCredentialsDemo
{
    public class Customer
    {
        string _accountSid, _authToken;

        public Customer()
        {
            _accountSid = System.Configuration.ConfigurationManager.AppSettings["AccountSid"];
            _authToken = System.Configuration.ConfigurationManager.AppSettings["AuthToken"];
        }

        internal Customer(string accountSid, string authToken)
        {
            _accountSid = accountSid;
            _authToken = authToken;
        }

        public string PhoneNumber { get; private set; }

        public bool BuyNumber(string number) 
        {
            var client = new TwilioRestClient(_accountSid, _authToken);
            var incoming = client.AddIncomingPhoneNumber(
                new PhoneNumberOptions()
                {
                    PhoneNumber = number,
                    VoiceUrl = "http://example.com/Call"
                });

            if (incoming.RestException != null)
            {
                //TODO: Log an error
                return false;
            }
            else
            {
                this.PhoneNumber = incoming.PhoneNumber;
                return true;
            }
        }
        
        public bool BuyNumberFromAreaCode(string areacode) 
        {
            var client = new TwilioRestClient(_accountSid, _authToken);
            var incoming = client.AddIncomingPhoneNumber(
                new PhoneNumberOptions()
                {
                    AreaCode = areacode,
                    VoiceUrl = "http://example.com/Call"
                });

            if (incoming.RestException != null)
            {
                //TODO: Log an error
                return false;
            }
            else
            {
                this.PhoneNumber = incoming.PhoneNumber;
                return true;
            }
        }
    }
}
