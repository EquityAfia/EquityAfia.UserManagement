using MediatR;
using EquityAfia.UserManagement.Contracts.AuthenticationDTOs.RegisterUserDTOs;

namespace EquityAfia.UserManagement.Application.Authentication.Commands.Register.RegisterUser
{
    public class RegisterUserCommand : IRequest<RegisterResponse>
    {
        // made the dto immutable by ommiting the set
        public UserRegistrationDto User { get; }

        public RegisterUserCommand(UserRegistrationDto user)
        {
            User = user;
        }
    }
}