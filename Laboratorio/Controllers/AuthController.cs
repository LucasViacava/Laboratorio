using Laboratorio.DTOs;
using Laboratorio.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] EmpleadoLoginDTO userLogin)
    {
        var token = _authService.Authenticate(userLogin.Username, userLogin.Password);

        if (string.IsNullOrEmpty(token))
        {
            return Unauthorized("Usuario o contraseña incorrectos");
        }

        return Ok(new { token });
    }
}

public class UserLogin
{
    public string Username { get; set; }
    public string Password { get; set; }
}
