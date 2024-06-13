using MediatR;
using EquityAfia.UserManagement.Application.Dtos;

namespace EquityAfia.UserManagement.Application.Authentication.Commands.Register.RegisterUser
{
    public class RegisterUserCommand : IRequest<Guid>
    {
        public UserRegistrationDto User { get; set; }

        public RegisterUserCommand(UserRegistrationDto user)
        {
            User = user;
        }
    }
}