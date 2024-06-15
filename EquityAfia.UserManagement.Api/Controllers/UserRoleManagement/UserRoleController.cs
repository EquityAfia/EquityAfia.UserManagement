using AutoMapper;
using EquityAfia.UserManagement.Application.UserCRUD.Commands.UpdateUser;
using EquityAfia.UserManagement.Application.UserRoleManagement.Commands.AddRole;
using EquityAfia.UserManagement.Application.UserRoleManagement.Commands.UpdateRole;
using EquityAfia.UserManagement.Contracts.UserRoleAndTypeManagement.UserRole;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Api.Controllers.UserRoleManagement
{
    [ApiController]
    [Route("Roles")]
    public class UserRoleController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserRoleController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost("create-roles")]
        public async Task<IActionResult> AddUserRole([FromBody] UserRoleRequest userRoleRequest)
        {
            var command = new AddRoleCommand(userRoleRequest);

            var response = await _mediator.Send(command);

            var mappedResponse = _mapper.Map<UserRoleResponse>(response);

            return Ok(mappedResponse);
        }

        [HttpPut("update-roles/{roleId}")]
        public async Task<IActionResult> UpdateRoles(int roleId, [FromBody] UserRoleRequest userRoleRequest)
        {
            var command = new UpdateRoleCommand(roleId, userRoleRequest.RoleName);

            var response = await _mediator.Send(command);

            return Ok(response); 
        }
    }
}
