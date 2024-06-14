using EquityAfia.UserManagement.Contracts.Authentication.RegisterUser;
using EquityAfia.UserManagement.Domain.RolesAggregate.RolesEntity;

namespace EquityAfia.UserManagement.Contracts.Authentication.RegisterPractitioner
{
    public class PractitionerRegistrationRequest : UserRegistrationDto
    {
        public string LicenseNumber { get; set; }
        public string PractitionerType { get; set; }
        public List<string> UserRoles { get; set; }
    }
}