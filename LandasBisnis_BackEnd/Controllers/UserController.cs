using LandasBisnis_BackEnd.Contracts;
using LandasBisnis_BackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LandasBisnis_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService user) : ControllerBase
    {
        private readonly IUserService _user = user;

        [HttpPost("login")]
        public async Task<IActionResult> Login(Credential credential){
            var result = await _user.Login(credential);
            if(result == null) return BadRequest();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? id){
            var result = await _user.Get();
            return Ok(result);
        }
    }
}
