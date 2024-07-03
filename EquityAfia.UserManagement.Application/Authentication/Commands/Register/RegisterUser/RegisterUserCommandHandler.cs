using MediatR;
using EquityAfia.UserManagement.Domain.UserAggregate.UsersEntities;
using EquityAfia.UserManagement.Application.Interfaces;
using EquityAfia.UserManagement.Application.Authentication.Common;
using MassTransit;
using EquityAfia.UserManagement.Application.Interfaces.UserRoleAndTypeRepositories;
using EquityAfia.SharedContracts;
using EquityAfia.UserManagement.Contracts.AuthenticationDTOs.RegisterUserDTOs;


namespace EquityAfia.UserManagement.Application.Authentication.Commands.Register.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IPublishEndpoint _publishEndpoint;

        public RegisterUserCommandHandler(
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IJwtTokenGenerator jwtTokenGenerator,
            IPublishEndpoint publishEndpoint)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<RegisterResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userDto = request.User;

                // Check if user exists in the database
                var existingUser = await _userRepository.UserExists(userDto.Email);

                if(existingUser)
                {
                    throw new ApplicationException($"User with email: '{userDto.Email}' already exists");
                }

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

                // Assign roles to the user
                await UserRolesAssigner.AssignRolesToUserAsync(_userRepository, _roleRepository, user, userDto.UserRoles);

                // Save user to repository
                await _userRepository.AddUserAsync(user);

                // Create the response
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

                // Publish UserRegistered event
                var userRegisteredEvent = new UserRegistered
                {
                    UserId = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    CreatedDate = user.CreatedDate 
                };

                await _publishEndpoint.Publish(userRegisteredEvent);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
