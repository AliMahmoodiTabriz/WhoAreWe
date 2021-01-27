using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Text;

namespace Core.Utilities.Exceptions
{
    public class AuthException: AuthenticationException
    {
        public string MessageId { get; set; }
        public AuthException(string message, string messageId) : base(message)
        {
            MessageId = messageId;
        }
    }
}
