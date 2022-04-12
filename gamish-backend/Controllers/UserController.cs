using gamish_backend.Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO_s.POST;
using System.Threading.Tasks;

namespace gamish_backend.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly ServiceUoW _serviceUoW;
        public UserController(ServiceUoW service)
        {
            _serviceUoW = service;
        }

        [HttpGet("VerifyUser")]
        public async Task<IActionResult> CheckUser(string login)
        {
            var response = await _serviceUoW.UserService.CheckIfLoginExistes(login);
            return Ok(new { Message = response });
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(PostLogin login)
        {
            var response = await _serviceUoW.UserService.CreateLogin(login);
            return Ok(response);
        }
    }
}
