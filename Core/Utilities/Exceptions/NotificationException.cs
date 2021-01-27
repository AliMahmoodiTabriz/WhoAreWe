using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Exceptions
{
   public class NotificationException: Exception
    {
        public string MessageId { get; set; }
        public NotificationException(string message, string messageId) : base(message)
        {
            MessageId = messageId;
        }
    }
}
