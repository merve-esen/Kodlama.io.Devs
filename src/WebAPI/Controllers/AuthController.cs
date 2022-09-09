using Application.Features.Auth.Commands.Login;
using Application.Features.Auth.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand registerCommand)
        {
            var result = await Mediator.Send(registerCommand);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginCommand loginCommand)
        {
            var result = await Mediator.Send(loginCommand);
            return Ok(result);
        }
    }
}
