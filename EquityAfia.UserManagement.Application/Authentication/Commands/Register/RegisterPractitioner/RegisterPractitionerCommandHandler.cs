
using MediatR;
using EquityAfia.UserManagement.Domain.UserAggregate.UsersEntities;
using EquityAfia.UserManagement.Application.Interfaces;

namespace EquityAfia.UserManagement.Application.Authentication.Commands.Register.RegisterPractitioner
{
    public class RegisterPractitionerCommandHandler : IRequestHandler<RegisterPractitionerCommand, Guid>
    {
        private readonly IUserRepository _userRepository;

        public RegisterPractitionerCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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

            await _userRepository.AddUserAsync(practitioner);
            return practitioner.Id;
        }
    }
}