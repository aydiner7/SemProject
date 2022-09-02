using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;

        // API nin appsetting dosyasına yazdığımız config kısıtlamalarını çekerek işlem yapar.
        // IConfiguration : API deki config dosyamı okumaya yarıyor.
        // TokenOptions : Okunan değerleri tutar.
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        //Token üretilirken config dosyasına yazdığım değerler baz alınır.
        public AccessToken CreateToken(User denemeUser, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, denemeUser, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        // Json Web Token üretiminde gerekli olan bilgiler olmadan üretim gerçekleşmez.
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User denemeUser,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(denemeUser, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        // .Net de var olan Claim in içeriği yetersiz olduğu için nesneye yeni methotlar ekledim.
        
        private IEnumerable<Claim> SetClaims(User denemeUser, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(denemeUser.Id.ToString());
            claims.AddEmail(denemeUser.Email);
            claims.AddName($"{denemeUser.FirstName} {denemeUser.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }

    }
}