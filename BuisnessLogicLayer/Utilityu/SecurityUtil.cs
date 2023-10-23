using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using DataAccessLayer.Entities;

namespace BuisnessLogicLayer
{
    public class SecurityUtil
    {
        public static string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            byte[] key = Encoding.ASCII.GetBytes("mjnhgvftdoqowevla");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserName.ToString()),
                    new Claim(ClaimTypes.GivenName, user.LastName.ToString()),
                    new Claim("Sid", user.Id.ToString()),
                }),
                
                Expires = DateTime.Now.AddDays(1), 
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = "https://localhost:7136/swagger/index.html",
                Audience = "MyAPI",
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

