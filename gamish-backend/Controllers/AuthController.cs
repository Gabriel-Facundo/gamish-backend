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
        private readonly ServiceUoW _service;
        public AuthController(ServiceUoW service)
        {
            _service = service;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            var response = await _service.AuthService.Login(login);
            return Ok(response);
        }
    }
}
