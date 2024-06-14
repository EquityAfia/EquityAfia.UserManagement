
using AutoMapper;
using EquityAfia.UserManagement.Application.Authentication.Commands.Register.RegisterUser;
using EquityAfia.UserManagement.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EquityAfia.UserManagement.Api.Controllers.Authentication.Register
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterUserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RegisterUserController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
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

                var mappedResponse = _mapper.Map<RegisterResponse>(userId);

                return Ok(mappedResponse);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
