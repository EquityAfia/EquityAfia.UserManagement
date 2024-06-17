using Microsoft.Extensions.Logging;
using EquityAfia.UserManagement.Application.Authentication.Common;
using EquityAfia.UserManagement.Application.Interfaces;
using EquityAfia.UserManagement.Domain.UserAggregate.UsersEntities;
using MediatR;
using EquityAfia.UserManagement.Contracts.Authentication.RegisterUser;
using EquityAfia.UserManagement.Application.Interfaces.UserRoleAndTypeRepositories;
using EquityAfia.UserManagement.Domain.RolesAndTypesAggregate.RolesAndTypesEntity;

namespace EquityAfia.UserManagement.Application.Authentication.Commands.Register.RegisterPractitioner
{
    public class RegisterPractitionerCommandHandler : IRequestHandler<RegisterPractitionerCommand, RegisterResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ILogger<RegisterPractitionerCommandHandler> _logger;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public RegisterPractitionerCommandHandler(
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            ILogger<RegisterPractitionerCommandHandler> logger,
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _jwtTokenGenerator = jwtTokenGenerator ?? throw new ArgumentNullException(nameof(jwtTokenGenerator));
        }

        public async Task<RegisterResponse> Handle(RegisterPractitionerCommand request, CancellationToken cancellationToken)
        {
            var practitionerDto = request.Practitioner;

            try
            {
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(practitionerDto.Password);

                var practitioner = new Practitioner
                {
                    FirstName = practitionerDto.FirstName,
                    LastName = practitionerDto.LastName,
                    Email = practitionerDto.Email,
                    PhoneNumber = practitionerDto.PhoneNumber,
                    IdNumber = practitionerDto.IdNumber,
                    Location = practitionerDto.Location,
                    DateOfBirth = practitionerDto.DateOfBirth,
                    Password = hashedPassword,
                    LicenseNumber = practitionerDto.LicenseNumber,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow
                };

                try
                {
                    await UserRolesAssigner.AssignRolesToUserAsync(_userRepository, _roleRepository, practitioner, practitionerDto.UserRoles);
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error assigning roles to practitioner", ex);
                }

                // Save practitioner to the database
                await _userRepository.AddUserAsync(practitioner);

                var token = _jwtTokenGenerator.GenerateToken(practitioner);

                var response = new RegisterResponse
                {
                    FirstName = practitioner.FirstName,
                    LastName = practitioner.LastName,
                    Email = practitioner.Email,
                    PhoneNumber = practitioner.PhoneNumber,
                    IdNumber = practitioner.IdNumber,
                    Location = practitioner.Location,
                    LicenseNumber = practitioner.LicenseNumber,
                    UserRoles = practitioner.UserRoles.Select(ur => ur.Role.ToString()).ToList(),
                    PractitionerType = practitioner.PractitionerTypes.ToList()
                };

                return response;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An unexpected error occurred while registering the practitioner", ex);
            }
        }
    }
}
