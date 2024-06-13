using EquityAfia.UserManagement.Domain.UserAggregate.UsersEntities;
using EquityAfia.UserManagement.Domain.RolesAggregate.RolesEntity;
using EquityAfia.UserManagement.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

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

            // Create the user entity from the DTO
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

            // Assign roles to the user
            if (userDto.UserRoles != null && userDto.UserRoles.Count > 0)
            {
                foreach (var roleName in userDto.UserRoles)
                {
                    // Fetch the role based on role name
                    var role = await _roleRepository.GetRoleByNameAsync(roleName);
                    if (role != null)
                    {
                        // Create UserRole and add it to the user's UserRoles collection
                        user.UserRoles.Add(new UserRole
                        {
                            Id = Guid.NewGuid(),
                            User = user,
                            RoleId = role.RoleId,
                            Role = role
                        });
                    }
                }
            }

            // Save the user along with their roles
            await _userRepository.AddUserAsync(user);

            return user.Id;
        }
    }
}
