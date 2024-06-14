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

        [HttpGet]
        public async Task<IActionResult> GetUserByEmail([FromQuery] GetUserRequest getUserRequest = null)
        {
            var command = new GetUserCommand(getUserRequest);

            var response = await _mediator.Send(command);

            if (response == null)
            {
                return NotFound("User not found");
            }

            var mappedResponse = _mapper.Map<GetUserResponse>(response);

            return Ok(mappedResponse);
        }
    }
}
