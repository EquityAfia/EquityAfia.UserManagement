using AutoMapper;
using EquityAfia.UserManagement.Application.UserCRUD.Commands.DeleteUser;
using EquityAfia.UserManagement.Application.UserCRUD.Commands.UpdateUser;
using EquityAfia.UserManagement.Application.UserCRUD.Queries.GetAllUsers;
using EquityAfia.UserManagement.Application.UserCRUD.Queries.GetUser;
using EquityAfia.UserManagement.Contracts.UserCRUD.DeleteUser;
using EquityAfia.UserManagement.Contracts.UserCRUD.GetUser;
using EquityAfia.UserManagement.Contracts.UserCRUD.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Api.Controllers.UserCRUD
{
    [ApiController]
    [Route("api")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("get-one-user")]
        public async Task<IActionResult> GetUserByEmail([FromQuery] GetUserRequest getUserRequest = null)
        {
            try
            {
                var query = new GetUserQuery(getUserRequest);

                var response = await _mediator.Send(query);

                if (response == null)
                {
                    return NotFound("User not found");
                }

                var mappedResponse = _mapper.Map<GetUserResponse>(response);

                return Ok(mappedResponse);
            }catch (Exception ex)
            {
                return StatusCode(500, $"An unexpected error occoured while executing get one user controller: {ex.Message}");
            }
        }

        [HttpGet("get-all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var query = new GetAllUsersQuery();
                var users = await _mediator.Send(query);

                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An unexpected error occoured while executing get all users controller: {ex.Message}");
            }
        }

        [HttpPut("update-user")]
        public async Task<IActionResult> UpdateUserDetails(string? idNumber, string? email, [FromBody] UpdateUserRequest updateUserRequest)
        {
            try
            {
                var command = new UpdateUserCommand(updateUserRequest);
                var response = await _mediator.Send(command);

                var mappedResponse = _mapper.Map<UpdateUserResponse>(response);
                return Ok(mappedResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An unexpected error occoured while executing update user controller: {ex.Message}");
            }
        }

        [HttpDelete("delete-user")]
        public async Task<IActionResult> DeleteUser(string? IdNumber, string? Email)
        {
            try
            {
                var command = new DeleteUserCommand();
                var response = await _mediator.Send(command);

                var mappedResponse = _mapper.Map<DeleteUserResponse>(response);
                return Ok(mappedResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An unexpected error occoured while executing delete user controller: {ex.Message}");
            }
        }
    }
}
