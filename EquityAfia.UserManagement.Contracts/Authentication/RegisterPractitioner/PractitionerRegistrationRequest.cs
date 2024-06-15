using EquityAfia.UserManagement.Contracts.Authentication.RegisterUser;

namespace EquityAfia.UserManagement.Contracts.Authentication.RegisterPractitioner
{
    public class PractitionerRegistrationRequest : UserRegistrationDto
    {
        public string LicenseNumber { get; set; }
        public string PractitionerType { get; set; }
        public List<string> UserRoles { get; set; }
    }
}