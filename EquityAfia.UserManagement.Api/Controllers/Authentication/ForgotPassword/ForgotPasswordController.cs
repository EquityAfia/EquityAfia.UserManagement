using AutoMapper;
using EquityAfia.UserManagement.Application.Authentication.Commands.ForgotPassword;
using EquityAfia.UserManagement.Contracts.Authentication.Forgotpassword;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EquityAfia.UserManagement.Api.Controllers.Authentication.ForgotPassword
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ForgotPasswordController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ForgotPasswordController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword([FromBody]ForgotPasswordRequest forgotPasswordRequest)
        {
            var forgotPasswordCommand = new ForgotPasswordCommand(forgotPasswordRequest);

            var response = await _mediator.Send(forgotPasswordCommand);

            var mappedResponse = _mapper.Map<ForgotPasswordResponse>(response);

            return Ok(mappedResponse);
        }
    }
}
