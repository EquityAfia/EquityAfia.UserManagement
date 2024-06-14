using MediatR;
using EquityAfia.UserManagement.Contracts.Authentication;

namespace EquityAfia.UserManagement.Application.Authentication.Commands.Register.RegisterUser
{
    public class RegisterUserCommand : IRequest<RegisterResponse>
    {
        public UserRegistrationDto User { get; set; }

        public RegisterUserCommand(UserRegistrationDto user)
        {
            User = user;
        }
    }
}