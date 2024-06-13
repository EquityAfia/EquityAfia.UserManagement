using EquityAfia.UserManagement.Application.Dtos;
using EquityAfia.UserManagement.Domain.RolesAggregate.RolesEntity;

namespace EquityAfia.UserManagement.Contracts.Authentication
{
    public class PractitionerRegistrationDto : UserRegistrationDto
    {
        public string LicenseNumber { get; set; }
        public PractitionerType PractitionerType { get; set; }
    }
}