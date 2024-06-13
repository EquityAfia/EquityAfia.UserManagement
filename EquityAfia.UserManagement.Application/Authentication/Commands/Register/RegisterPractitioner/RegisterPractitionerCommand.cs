using MediatR;
using EquityAfia.UserManagement.Contracts.Authentication;

namespace EquityAfia.UserManagement.Application.Authentication.Commands.Register.RegisterPractitioner
{
    public class RegisterPractitionerCommand : IRequest<Guid>
    {
        public PractitionerRegistrationDto Practitioner { get; set; }

        public RegisterPractitionerCommand(PractitionerRegistrationDto practitioner)
        {
            Practitioner = practitioner;
        }
    }
}