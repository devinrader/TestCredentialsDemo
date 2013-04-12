using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;

namespace TestCredentialsDemo
{
    public class Message
    {
        string _accountSid, _authToken;

        internal Message()
        {
            _accountSid = System.Configuration.ConfigurationManager.AppSettings["AccountSid"];
            _authToken = System.Configuration.ConfigurationManager.AppSettings["AuthToken"];
        }

        public string From { get; internal set; }
        public string To { get; internal set; }

        public MessageStatus Status { get; internal set; }

        public void Send()
        {
            var client = new TwilioRestClient(_accountSid, _authToken);
            var message = client.SendSmsMessage(From, To, "Thanks for trying out our service.");
            if (message.RestException != null)
            {
                //TODO: log the error

                this.Status = MessageStatus.Fail;
            }
            else
            {
                this.Status = MessageStatus.Success;
            }
        }

        internal void Send(string accountSid, string authToken) {
            _accountSid = accountSid;
            _authToken = authToken;

            Send();
        }
    }

    public enum MessageStatus {
        Unsent,
        Success,
        Fail
    }
}
