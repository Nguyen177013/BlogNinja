using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebBlog.Models;

namespace WebBlog.Utils
{
    public class JwtUtils
    {
        public string GenerateJwtToken(Author author)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            string key = Environment.GetEnvironmentVariable("ASPNETCORE_JWT_SECRET");
            byte[] secretKey = Encoding.UTF8.GetBytes(key);
            if (key == null)
            {
                throw new ArgumentNullException();
            }
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("UserName", author.UserName),
                    new Claim("UserId", author.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }
    }
}
