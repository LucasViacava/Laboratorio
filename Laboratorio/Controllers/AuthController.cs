using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly string _secretKey;

    public AuthController(IConfiguration config)
    {
        // Obtiene la clave secreta desde el archivo de configuración
        _secretKey = config.GetValue<string>("Jwt:Key");
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] UserLogin userLogin)
    {
        // Validación simple del usuario (puedes reemplazar esto con la lógica que necesites)
        if (userLogin.Username == "admin" && userLogin.Password == "password")
        {
            // Crear el token JWT
            var token = GenerateJwtToken(userLogin.Username);
            return Ok(new { token });
        }

        return Unauthorized("Usuario o contraseña incorrectos");
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

public class UserLogin
{
    public string Username { get; set; }
    public string Password { get; set; }
}
