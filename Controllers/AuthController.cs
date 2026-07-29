using Microsoft.AspNetCore.Mvc;

namespace GestorTorneosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (request.Usuario == "admin" && request.Password == "admin123")
            {
                return Ok(new { token = "token-simulado-jwt-12345", mensaje = "Autenticación exitosa" });
            }
            return Unauthorized(new { mensaje = "Credenciales incorrectas" });
        }
    }

    public class LoginRequest
    {
        public string Usuario { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}