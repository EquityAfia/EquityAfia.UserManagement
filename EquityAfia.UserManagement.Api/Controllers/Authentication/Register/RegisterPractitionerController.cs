using MediatR;
using Microsoft.AspNetCore.Mvc;
using EquityAfia.UserManagement.Application.Authentication.Commands.Register.RegisterPractitioner;
using EquityAfia.UserManagement.Domain.UserAggregate.UsersEntities;
using AutoMapper;
using EquityAfia.UserManagement.Contracts.Authentication.RegisterPractitioner;
using EquityAfia.UserManagement.Contracts.Authentication.RegisterUser;

namespace EquityAfia.UserManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterPractitionerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<RegisterPractitionerController> _logger;
        private readonly IMapper _mapper;

        public RegisterPractitionerController(IMediator mediator, ILogger<RegisterPractitionerController> logger, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterPractitioner([FromBody] PractitionerRegistrationRequest practitionerDto)
        {
            
            var command = new RegisterPractitionerCommand(practitionerDto);
            var practitionerId = await _mediator.Send(command);

            var mappedResponse = _mapper.Map<RegisterResponse>(practitionerId);

            return Ok(mappedResponse);

        }
    }
}
