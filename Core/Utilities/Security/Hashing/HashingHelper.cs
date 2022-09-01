using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        // Verdiğim passwordu, Hash ve Salt olarak dışarı verecek.
        // out: Dışarıya verilecek Değer
        // Passwordları 2li binary sisteminde istediğimiz için string değeri çeviriyoruz.



        // password un Hashini hazırlayan methodum
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            // Hashing oluştururken SHA512 algoritmasını kullanacağımı belirttim.
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        // PasswordHash doğrula / Salt ila doğrulama yapar.
        // Kullanıcının girdiği passwordu Hashleyerek, ilgili Salt ile eşleşip eşleşmediğini kontrol ediyor.
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }

                }
                return true;
            }            
        }
    }
}
