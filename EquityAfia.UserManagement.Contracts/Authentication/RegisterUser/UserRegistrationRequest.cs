using EquityAfia.UserManagement.Domain.RolesAggregate.RolesEntity;

namespace EquityAfia.UserManagement.Contracts.Authentication.RegisterUser
{
    public class UserRegistrationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string IdNumber { get; set; }
        public string Location { get; set; }
        public string DateOfBirth { get; set; }
        public string Password { get; set; }
        public List<string> UserRoles { get; set; }
        public string PractitionerType { get; set; }
    }
}