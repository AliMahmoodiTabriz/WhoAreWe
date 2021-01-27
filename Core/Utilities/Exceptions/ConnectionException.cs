using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Exceptions
{
    public class ConnectionException : Exception
    {
        public string MessageId { get; set; }
        public ConnectionException(string message,string messageId):base(message)
        {
            MessageId = messageId;
        }
    }
}
