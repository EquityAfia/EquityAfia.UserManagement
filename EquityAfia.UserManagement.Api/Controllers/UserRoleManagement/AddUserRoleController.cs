using AutoMapper;
using EquityAfia.UserManagement.Application.UserRoleManagement.Commands.AddRole;
using EquityAfia.UserManagement.Contracts.UserRoleAndTypeManagement.UserRole;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Api.Controllers.UserRoleManagement
{
    [ApiController]
    [Route("/user-roles/[Controller]")]
    public class AddUserRoleController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AddUserRoleController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddUserRole([FromBody] UserRoleRequest userRoleRequest)
        {
            var command = new AddRoleCommand(userRoleRequest);

            var response = await _mediator.Send(command);

            var mappedResponse = _mapper.Map<UserRoleResponse>(response);

            return Ok(mappedResponse);
        }
    }
}
