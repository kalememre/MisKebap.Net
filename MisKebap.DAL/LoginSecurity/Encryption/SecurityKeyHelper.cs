using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace MisKebap.DAL.LoginSecurity.Encryption
{
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }

        public static SecurityKey CreateSecurityKey(object securityKey)
        {
            throw new NotImplementedException();
        }
    }
}
