using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Laboratorio.Services
{
    public class AuthService
    {
        private readonly string _secretKey;

        public AuthService(IConfiguration config)
        {
            _secretKey = config.GetValue<string>("JwtSettings:Key");
        }

        public string Authenticate(string username, string password)
        {
            // Simula una validación básica de usuario.
            if (username == "admin" && password == "password")
            {
                return GenerateJwtToken(username);
            }
            return string.Empty;
        }

        private string GenerateJwtToken(string username)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
