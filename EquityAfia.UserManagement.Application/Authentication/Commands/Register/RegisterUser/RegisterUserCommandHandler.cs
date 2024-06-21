using MediatR;
using EquityAfia.UserManagement.Domain.UserAggregate.UsersEntities;
using EquityAfia.UserManagement.Application.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using EquityAfia.UserManagement.Application.Authentication.Common;
using BCrypt.Net;
using EquityAfia.UserManagement.Contracts.Authentication.RegisterUser;
using EquityAfia.UserManagement.Application.Interfaces.UserRoleAndTypeRepositories;

namespace EquityAfia.UserManagement.Application.Authentication.Commands.Register.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public RegisterUserCommandHandler(IUserRepository userRepository, IRoleRepository roleRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<RegisterResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var userDto = request.User;

                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

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
                    Password = hashedPassword,
                    UserType = userDto.UserType,
                    LicenseNumber = userDto.LicenseNumber,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow
                };

                // var token = _jwtTokenGenerator.GenerateToken(user);

                await UserRolesAssigner.AssignRolesToUserAsync(_userRepository, _roleRepository, user, userDto.UserRoles);

                var response = new RegisterResponse
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    IdNumber = user.IdNumber,
                    Location = user.Location,
                    UserRoles = userDto.UserRoles,
                };

                return response;

            }catch(Exception ex)
            {
                throw new ApplicationException(ex.ToString());
            }
            
        }
    }
}
