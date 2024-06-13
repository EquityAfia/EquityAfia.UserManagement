using EquityAfia.UserManagement.Domain.RolesAggregate.RolesEntity;

namespace EquityAfia.UserManagement.Application.Dtos
{
    public class UserRegistrationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string IdNumber { get; set; }
        public string Location { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Password { get; set; }
        public List<string> UserRoles { get; set; } 
        public PractitionerType? PractitionerType { get; set; }
    }
}