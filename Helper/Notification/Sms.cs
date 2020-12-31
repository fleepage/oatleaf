using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telesign;

namespace fleepage.oatleaf.com.Helper.Notification
{
    public class Sms
    {
        public static bool SendSms()
        {
            string customerId = "D4FABCB8-B645-482C-9BF7-545DCD771C5F";
            string apiKey = "4NErG3wdFqvIUkNUZq6UsljsCDg4IfXOH+f5axxDXdz4GdOh7Z/ro5QeG5PGt9vjTvgfw3QhyZOyN046f2OGgg==";

            string phoneNumber = "2348023381943";

            string message = "You're scheduled for a dentist appointment at 2:30PM.";
            string messageType = "ARN";

            try
            {
                MessagingClient messagingClient = new MessagingClient(customerId, apiKey);
                RestClient.TelesignResponse telesignResponse = messagingClient.Message(phoneNumber, message, messageType);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

    }
}
