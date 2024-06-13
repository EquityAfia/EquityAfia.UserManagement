
using Microsoft.Extensions.Logging;
using EquityAfia.UserManagement.Application.Authentication.Common;
using EquityAfia.UserManagement.Application.Interfaces;
using EquityAfia.UserManagement.Domain.UserAggregate.UsersEntities;
using MediatR;

namespace EquityAfia.UserManagement.Application.Authentication.Commands.Register.RegisterPractitioner
{
    public class RegisterPractitionerCommandHandler : IRequestHandler<RegisterPractitionerCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ILogger<RegisterPractitionerCommandHandler> _logger;

        public RegisterPractitionerCommandHandler(IUserRepository userRepository, IRoleRepository roleRepository, ILogger<RegisterPractitionerCommandHandler> logger)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _logger = logger;
        }

        public async Task<Guid> Handle(RegisterPractitionerCommand request, CancellationToken cancellationToken)
        {
            var practitionerDto = request.Practitioner;

            var practitioner = new Practitioner
            {
                Id = Guid.NewGuid(),
                FirstName = practitionerDto.FirstName,
                LastName = practitionerDto.LastName,
                Email = practitionerDto.Email,
                PhoneNumber = practitionerDto.PhoneNumber,
                Location = practitionerDto.Location,
                DateOfBirth = practitionerDto.DateOfBirth,
                Password = practitionerDto.Password,
                LicenseNumber = practitionerDto.LicenseNumber,
                PractitionerType = practitionerDto.PractitionerType,
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

            return practitioner.Id;
        }
    }
}
