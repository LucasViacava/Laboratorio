using Laboratorio.Data;
using Microsoft.EntityFrameworkCore;
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
        private readonly RestauranteContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration config, RestauranteContext context)
        {
            _secretKey = config.GetValue<string>("JwtSettings:Key");
            _context = context;
            _configuration = config;
        }
        public string Authenticate(string username, string password)
        {
            var empleado = _context.Empleados.FirstOrDefault(e => e.UserName == username && e.Password == password);

            if (empleado != null)
            {
                return GenerateJwtToken(empleado.UserName);
            }

            return string.Empty;
        }
        private string GenerateJwtToken(string username)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(double.Parse(_configuration["JwtSettings:DurationInMinutes"])),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
