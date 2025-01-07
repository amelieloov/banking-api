using BankApp.Core.Interfaces;
using BankApp.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDTO userDto)
        {
            try
            {
                var token = await _service.VerifyLoginAsync(userDto);
                return Ok(new { Token = token });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new {message = ex.Message});
            }
        }
    }
}
