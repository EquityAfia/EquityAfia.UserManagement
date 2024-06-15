using AutoMapper;
using EquityAfia.UserManagement.Application.UserTypesManagement.Queries.GetUserTypes;
using EquityAfia.UserManagement.Contracts.UserRoleAndTypeManagement.UserRole;
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
    }
}
