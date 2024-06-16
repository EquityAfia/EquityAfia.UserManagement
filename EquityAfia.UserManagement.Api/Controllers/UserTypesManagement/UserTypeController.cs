using AutoMapper;
using EquityAfia.UserManagement.Application.UserTypesManagement.Commands.AddUserType;
using EquityAfia.UserManagement.Application.UserTypesManagement.Commands.UpdateUserType;
using EquityAfia.UserManagement.Application.UserTypesManagement.Queries.GetUserTypes;
using EquityAfia.UserManagement.Contracts.UserRoleAndTypeManagement.UserRole;
using EquityAfia.UserManagement.Contracts.UserRoleAndTypeManagement.UserType;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EquityAfia.UserManagement.Api.Controllers.UserTypesManagement
{
    [ApiController]
    [Route("User-Types")]
    public class UserTypeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public UserTypeController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet("view-all-usertypes")]
        public async Task<IActionResult> GetAllUserTypes()
        {
            var query = new GetUserTypeQuery();

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpPost("add-usertype")]
        public async Task<IActionResult> AddUserType([FromBody] UserTypeRequest userTypeRequest)
        {
            var command = new AddUserTypeCommand(userTypeRequest);

            var response = await _mediator.Send(command);
            var mappedResponse = _mapper.Map<UserTypeResponse>(response);

            return Ok(mappedResponse);
        }

        [HttpPut("update-type/{typeId}")]
        public async Task<IActionResult> UpdateUserType(int typeId, UserTypeRequest typeRequest)
        {
            var command = new UpdateUserTypeCommand(typeRequest,typeId);

            var response = await _mediator.Send(command);
            var mappoedResponse = _mapper.Map<UserTypeResponse>(response);

            return Ok(mappoedResponse);
        }
    }
}
