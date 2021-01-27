using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey secutiyKey)
        {
            return  new SigningCredentials(secutiyKey,SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
