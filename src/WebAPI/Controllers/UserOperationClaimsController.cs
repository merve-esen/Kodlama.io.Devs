using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using Application.Features.UserOperationClaims.Queries.GetByUserIdUserOperationClaim;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : BaseController
    {
        [HttpPost("GetByUserId")]
        public async Task<IActionResult> GetByUserId([FromBody] GetByUserIdUserOperationClaimQuery getByUserIdQuery)
        {
            UserOperationClaimGetByUserIdModel result = await Mediator.Send(getByUserIdQuery);
            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand createUserOperationClaimCommand)
        {
            CreatedUserOperationClaimDto result = await Mediator.Send(createUserOperationClaimCommand);
            return Created("", result);
        }

        [HttpPost("Delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserOperationClaimCommand deleteUserOperationClaimCommand)
        {
            await Mediator.Send(deleteUserOperationClaimCommand);
            return Ok();
        }
    }
}
