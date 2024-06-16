using EquityAfia.UserManagement.Application.Interfaces;
using EquityAfia.UserManagement.Contracts.UserCRUD.UpdateUser;
using EquityAfia.UserManagement.Domain.UserAggregate.UsersEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Application.UserCRUD.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetUserByEmailOrIdNumberAsync(request.Email, request.IdNumber);
                if (user == null)
                {
                    throw new Exception("User not found!!");
                }

                // Update user information
                user.UpdateUserInfo(
                    request.UpdateUserRequest.FirstName,
                    request.UpdateUserRequest.LastName,
                    user.Email,
                    request.UpdateUserRequest.PhoneNumber,
                    request.UpdateUserRequest.Location,
                    user.DateOfBirth
                );

                await _userRepository.UpdateUserAsync(user);

                var response = new UpdateUserResponse
                {
                    Message = "User updated successfully",
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    Location = user.Location
                };

                return response;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An unexpected error occoured while executing update user command handler", ex);
            }
        }
    }
}
