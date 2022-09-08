using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        // Kullanıcı giriş bilgilerini girdikten sonra API ye istek gelecek 
        /* Eğer doğru girdiyse, bu methodumuz çalışacak ve
         Token üretilip tekrar geri değer gönderilecek. */
        AccessToken CreateToken(User denemeUser, List<OperationClaim> operationClaims);

        // İlgili kullanıcıya ait yetkilendirmeleri bulacak, JWT üretip getirecek.
    }
}
