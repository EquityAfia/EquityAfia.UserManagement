using AutoMapper;
using EquityAfia.UserManagement.Application.UserCRUD.Commands.UpdateUser;
using EquityAfia.UserManagement.Application.UserRoleManagement.Commands.AddRole;
using EquityAfia.UserManagement.Application.UserRoleManagement.Commands.DeleteRole;
using EquityAfia.UserManagement.Application.UserRoleManagement.Commands.UpdateRole;
using EquityAfia.UserManagement.Application.UserRoleManagement.Queries.GetRoles;
using EquityAfia.UserManagement.Contracts.UserRoleAndTypeManagement.UserRole;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Api.Controllers.UserRoleManagement
{
    [ApiController]
    [Route("User-Roles")]
    public class UserRoleController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserRoleController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }


        [HttpGet("view-all-roles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var query = new GetRoleQuery();
            var roles = await _mediator.Send(query);

           // var response = _mapper.Map<List<UserRoleResponse>>(roles); 

            return Ok(roles);
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

        [HttpDelete("delete-roles/{roleId}")]
        public async Task<IActionResult> DeleteRole(int roleId)
        {
            var command = new DeleteRoleCommand(roleId);

            var response = await _mediator.Send(command);
            var mappedResponse = new UserRoleResponse
            {
                Message = response.Message
            };

            return Ok(mappedResponse);
        }
    }
}
