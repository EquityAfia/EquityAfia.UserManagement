
using Microsoft.Extensions.Logging;
using EquityAfia.UserManagement.Application.Authentication.Common;
using EquityAfia.UserManagement.Application.Interfaces;
using EquityAfia.UserManagement.Domain.UserAggregate.UsersEntities;
using MediatR;
using EquityAfia.UserManagement.Contracts.Authentication.RegisterUser;
using EquityAfia.UserManagement.Application.Interfaces.UserRoleAndTypeRepositories;

namespace EquityAfia.UserManagement.Application.Authentication.Commands.Register.RegisterPractitioner
{
    public class RegisterPractitionerCommandHandler : IRequestHandler<RegisterPractitionerCommand, RegisterResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ILogger<RegisterPractitionerCommandHandler> _logger;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public RegisterPractitionerCommandHandler(IUserRepository userRepository, IRoleRepository roleRepository, ILogger<RegisterPractitionerCommandHandler> logger, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _logger = logger;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<RegisterResponse> Handle(RegisterPractitionerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var practitionerDto = request.Practitioner;

                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(practitionerDto.Password);

                var practitioner = new Practitioner
                {
                    Id = Guid.NewGuid(),
                    FirstName = practitionerDto.FirstName,
                    LastName = practitionerDto.LastName,
                    Email = practitionerDto.Email,
                    PhoneNumber = practitionerDto.PhoneNumber,
                    IdNumber = practitionerDto.IdNumber,
                    Location = practitionerDto.Location,
                    DateOfBirth = practitionerDto.DateOfBirth,
                    Password = hashedPassword,
                    LicenseNumber = practitionerDto.LicenseNumber,
                    // UserRoles = practitionerDto.UserRoles,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow
                };

                try
                {
                    await UserRolesAssigner.AssignRolesToUserAsync(_userRepository, _roleRepository, practitioner, practitionerDto.UserRoles);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while registering practitioner.");
                    throw; // Propagate the exception to the controller
                }

                var token = _jwtTokenGenerator.GenerateToken(practitioner);


                var response = new RegisterResponse
                {
                    FirstName = practitioner.FirstName,
                    LastName = practitioner.LastName,
                    Email = practitioner.Email,
                    PhoneNumber = practitioner.PhoneNumber,
                    IdNumber = practitioner.IdNumber,
                    Location = practitioner.Location,
                    //  UserRoles = practitioner.UserRoles,
                    Token = token
                };

                return response;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An unexpected error occoured while executing register practitioner command handler", ex);
            }
        }
    }
}
