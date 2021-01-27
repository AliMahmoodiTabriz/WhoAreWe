using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Exceptions
{
    public class LicenseException : Exception
    {
        public string MessageId { get; set; }
        public LicenseException(string message, string messageId) : base(message)
        {
            MessageId = messageId;
        }
    }
}
