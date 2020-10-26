using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace JWTExample
{
    public class TokenGenerate
    {
        public string Token()
        {
            var byteArray = Encoding.UTF8.GetBytes("figensoftfigensoft123");

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(byteArray);

            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken securityToken = new JwtSecurityToken
                (
                    issuer: "https://localhost",
                    audience: "https://localhost",
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddMinutes(1),
                    signingCredentials: credentials
                );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            //Token Created
            return tokenHandler.WriteToken(securityToken);
        }
    }
}
