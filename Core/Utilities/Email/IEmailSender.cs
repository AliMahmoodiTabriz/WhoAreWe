using Core.Utilities.Email.MailKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Email

{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}
