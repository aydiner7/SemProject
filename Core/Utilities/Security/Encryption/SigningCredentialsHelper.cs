using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        // JWT sistemini yönetirken hangi anahtarı ve hangi algoritmayı kullanması gerektiğini belirtiyorum.
        // Hashing işlemi yaparken anahtar olarak, sana verdiğim keyi kullan.
        // Şifreleme olarakta SecurityAlgorithms.HmacSha256Signature kullan.
        public static SigningCredentials CreateSigningCredentials(SecurityKey security)
        {
            return new SigningCredentials(security, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}