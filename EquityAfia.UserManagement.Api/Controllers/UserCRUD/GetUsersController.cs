using AutoMapper;
using EquityAfia.UserManagement.Application.UserCRUD.Queries.GetUser;
using EquityAfia.UserManagement.Contracts.UserCRUD.GetUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Api.Controllers.UserCRUD
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            // Validate the email parameter
            if (string.IsNullOrWhiteSpace(email))
            {
                return BadRequest("Email cannot be empty");
            }

            // Create the command with the email
            var command = new GetUserCommand( email );

            // Send the command to the mediator and await the response
            var response = await _mediator.Send(command);

            // Check if the response is null (user not found)
            if (response == null)
            {
                return NotFound("User not found");
            }

            // Use AutoMapper to map the response to GetUserResponse
            var mappedResponse = _mapper.Map<GetUserResponse>(response);

            // Return the mapped response
            return Ok(mappedResponse);
        }
    }
}
