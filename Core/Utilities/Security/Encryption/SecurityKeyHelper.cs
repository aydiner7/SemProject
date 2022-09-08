using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{

    // Şifreleme olan sistemlerde, byte [] şeklinde vermemiz gerekiyor.
    // Kısacası, basit bir string şeklinde key oluşturamayız.
    // Key : API, config / Token üretimi için gerekli olan güvenlik anahtarı.
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
