using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        // Credentials : Sisteme giriş için istenen veriler. / Kimlik Bilgileri ( Kullanıcı Adı, Şifre )
        public static SigningCredentials CreateSigningCredentials(SecurityKey security)
        {
            return new SigningCredentials(security, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}