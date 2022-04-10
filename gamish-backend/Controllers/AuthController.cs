using Microsoft.AspNetCore.Mvc;
using Models;
using System.Threading.Tasks;

namespace gamish_backend.Controllers
{
    public class AuthController : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]Login login)
        {
            return Ok();
        }
    }
}
