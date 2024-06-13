using MediatR;
using EquityAfia.UserManagement.Domain.UserAggregate.UsersEntities;
using EquityAfia.UserManagement.Application.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using EquityAfia.UserManagement.Application.Authentication.Common;

namespace EquityAfia.UserManagement.Application.Authentication.Commands.Register.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public RegisterUserCommandHandler(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var userDto = request.User;

            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                IdNumber = userDto.IdNumber,
                Location = userDto.Location,
                DateOfBirth = userDto.DateOfBirth,
                Password = userDto.Password,  // Ensure to hash the password in a real scenario
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };

            await UserRolesAssigner.AssignRolesToUserAsync(_userRepository, _roleRepository, user, userDto.UserRoles);

            return user.Id;
        }
    }
}
