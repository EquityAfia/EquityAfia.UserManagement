
using EquityAfia.UserManagement.Application.Authentication.Commands.Register.RegisterUser;
using EquityAfia.UserManagement.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EquityAfia.UserManagement.Api.Controllers.Authentication.Register
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterUserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RegisterUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST api/user/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto userRegistrationDto)
        {
            // Validate the request
            if (userRegistrationDto == null)
            {
                return BadRequest("Invalid user registration data.");
            }

            try
            {
                // Create the command with the user registration data
                var command = new RegisterUserCommand(userRegistrationDto);

                var userId = await _mediator.Send(command);

                return Ok(new { UserId = userId });
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
