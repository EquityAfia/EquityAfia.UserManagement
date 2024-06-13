using MediatR;
using Microsoft.AspNetCore.Mvc;
using EquityAfia.UserManagement.Application.Authentication.Commands.Register.RegisterPractitioner;
using EquityAfia.UserManagement.Application.Dtos;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using EquityAfia.UserManagement.Contracts.Authentication;

namespace EquityAfia.UserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterPractitionerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<RegisterPractitionerController> _logger;

        public RegisterPractitionerController(IMediator mediator, ILogger<RegisterPractitionerController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterPractitioner([FromBody] PractitionerRegistrationDto practitionerDto)
        {
            try
            {
                var command = new RegisterPractitionerCommand(practitionerDto);
                var practitionerId = await _mediator.Send(command);

                return Ok(new { PractitionerId = practitionerId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering practitioner.");
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
