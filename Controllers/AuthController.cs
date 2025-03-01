using Microsoft.AspNetCore.Mvc;
using MongoDBCars.Services.Token;

namespace MongoDBCars.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("token")]
        public IActionResult GenerateToken()
        {
            // Chave secreta (deve ser a mesma usada na validação do token)
            var key = "uma_chave_secreta_muito_grande_e_segura";
            var issuer = "https://localhost:8080";
            var audience = "https://localhost:8080";

            // Gera o token
            var token = TokenService.GenerateToken(key, issuer, audience);

            // Retorna o token
            return Ok(new { token });
        }
    }
}