using AutoMapper;
using EquityAfia.UserManagement.Application.Authentication.Commands.ResetPassword;
using EquityAfia.UserManagement.Contracts.Authentication.ResetPassword;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EquityAfia.UserManagement.Api.Controllers.Authentication.ResetPassword
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ResetPasswordController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ResetPasswordController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest resetRequest)
        {
            var command = new ResetPasswordCommand(resetRequest);

            var response = await _mediator.Send(command);

            var mappedResponse = _mapper.Map<ResetPasswordResponse>(response);

            return Ok(mappedResponse);
        }
    }
}
