using EquityAfia.UserManagement.Domain.RolesAggregate.RolesEntity;

namespace EquityAfia.UserManagement.Contracts.Authentication
{
    public class PractitionerRegistrationRequest : UserRegistrationDto
    {
        public string LicenseNumber { get; set; }
        public string PractitionerType { get; set; }
        public List<string> UserRoles { get; set; }
    }
}