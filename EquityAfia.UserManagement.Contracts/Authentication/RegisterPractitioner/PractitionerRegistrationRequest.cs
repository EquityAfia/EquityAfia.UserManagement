using EquityAfia.UserManagement.Contracts.Authentication.RegisterUser;
using System.ComponentModel.DataAnnotations;

namespace EquityAfia.UserManagement.Contracts.Authentication.RegisterPractitioner
{
    public class PractitionerRegistrationRequest : UserRegistrationDto
    {
        [Required(ErrorMessage ="Liscense Number is required")]
        public string LicenseNumber { get; set; }
        public string PractitionerType { get; set; }
        public List<string> UserRoles { get; set; }
    }
}