using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCredentialsDemo
{
    public static class Notifications
    {
        public static Message CreateMessage(string to) {
            return new Message() 
            { 
                Status = MessageStatus.Unsent, 
                To = to,
                From = ConfigurationManager.AppSettings["From"] 
            };
        }

        public static Message CreateMessage(string from, string to)
        {
            return new Message()
            {
                Status = MessageStatus.Unsent,
                To = to,
                From = from
            };
        }

        public static Phone CreateCall(string to) {
            return new Phone() 
            { 
                Status = CallStatus.Unsent, 
                To = to,
                From = ConfigurationManager.AppSettings["From"] 
            };
        }
    }
}
