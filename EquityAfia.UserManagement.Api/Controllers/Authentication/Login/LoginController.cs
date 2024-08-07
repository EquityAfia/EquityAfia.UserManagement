﻿using AutoMapper;
using EquityAfia.UserManagement.Application.Authentication.Queries.LogIn;
using EquityAfia.UserManagement.Contracts.AuthenticationDTOs.LoginDTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EquityAfia.UserManagement.Api.Controllers.Authentication.Login
{
    [ApiController]
    [Route("/[Controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public LoginController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                var query = new LoginQuery(loginRequest);

                var logIn = await _mediator.Send(query);

                var mappedResponse = _mapper.Map<LoginResponse>(logIn);

                return Ok(mappedResponse);

            } catch (Exception ex)
            {
                return StatusCode(500, $"An unexpecded error occoured at log in controller: {ex} ");
            }
        }
    }
}
