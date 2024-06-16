using AutoMapper;
using EquityAfia.UserManagement.Application.Authentication.Commands.ForgotPassword;
using EquityAfia.UserManagement.Application.Authentication.Commands.ResetPassword;
using EquityAfia.UserManagement.Contracts.Authentication.Forgotpassword;
using EquityAfia.UserManagement.Contracts.Authentication.ResetPassword;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EquityAfia.UserManagement.Api.Controllers.Authentication.ForgotPassword;

[ApiController]
[Route("auth")]
public class PasswordController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public PasswordController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword([FromBody]ForgotPasswordRequest forgotPasswordRequest)
    {
        try
        {
            var forgotPasswordCommand = new ForgotPasswordCommand(forgotPasswordRequest);

            var response = await _mediator.Send(forgotPasswordCommand);

            var mappedResponse = _mapper.Map<ForgotPasswordResponse>(response);

            return Ok(mappedResponse);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An unexpecded error occoured at forgot password controller: {ex}");
        }
    }

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest resetRequest)
    {
        try
        {
            var command = new ResetPasswordCommand(resetRequest);

            var response = await _mediator.Send(command);

            var mappedResponse = _mapper.Map<ResetPasswordResponse>(response);

            return Ok(mappedResponse);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An unexpecded error occoured at reset password controller: {ex} ");
        }
    }
}
