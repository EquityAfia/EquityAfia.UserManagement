using MediatR;
using EquityAfia.UserManagement.Contracts.Authentication.RegisterPractitioner;
using EquityAfia.UserManagement.Contracts.Authentication.RegisterUser;

namespace EquityAfia.UserManagement.Application.Authentication.Commands.Register.RegisterPractitioner
{
    public class RegisterPractitionerCommand : IRequest<RegisterResponse>
    {
        public PractitionerRegistrationRequest Practitioner { get; set; }

        public RegisterPractitionerCommand(PractitionerRegistrationRequest practitioner)
        {
            Practitioner = practitioner;
        }
    }
}