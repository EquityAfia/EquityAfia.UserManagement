﻿
using AutoMapper;
using EquityAfia.UserManagement.Application.Authentication.Commands.Register.RegisterUser;
using EquityAfia.UserManagement.Contracts.AuthenticationDTOs.RegisterUserDTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EquityAfia.UserManagement.Api.Controllers.Authentication.Register
{
    [ApiController]
    [Route("auth")]
    public class RegisterUserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RegisterUserController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        // POST api/user/register
        [HttpPost("register-user")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto userRegistrationDto)
        {

            try
            {
                var command = new RegisterUserCommand(userRegistrationDto);

                var userId = await _mediator.Send(command);

                var mappedResponse = _mapper.Map<RegisterResponse>(userId);

                return Ok(mappedResponse);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
