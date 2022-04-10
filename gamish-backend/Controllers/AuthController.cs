using Database.DB;
using gamish_backend.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Data;
using System.Threading.Tasks;

namespace gamish_backend.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly AuthService _auth;
        public AuthController(AuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            var response = await _auth.Login(login);
            return Ok(new {Message = response });
        }
    }
}
