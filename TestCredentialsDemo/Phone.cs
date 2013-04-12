using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;

namespace TestCredentialsDemo
{
    public class Phone
    {
        string _accountSid, _authToken;

        internal Phone()
        {
            _accountSid = System.Configuration.ConfigurationManager.AppSettings["AccountSid"];
            _authToken = System.Configuration.ConfigurationManager.AppSettings["AuthToken"];
        }

        public string From { get; internal set; }
        public string To { get; internal set; }

        public CallStatus Status { get; internal set; }

        public void Initiate()
        {
            var client = new TwilioRestClient(_accountSid, _authToken);
            var message = client.InitiateOutboundCall(From, To, "http://example.com/thankyou");
            if (message.RestException != null)
            {
                //TODO: log the error

                this.Status = CallStatus.Fail;
            }
            else
            {
                this.Status = CallStatus.Success;
            }
        }

        internal void Initiate(string accountSid, string authToken)
        {
            _accountSid = accountSid;
            _authToken = authToken;

            Initiate();
        }
    }

    public enum CallStatus
    {
        Unsent,
        Success,
        Fail
    }
}
