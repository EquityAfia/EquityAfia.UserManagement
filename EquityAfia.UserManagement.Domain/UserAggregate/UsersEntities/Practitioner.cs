

using EquityAfia.UserManagement.Domain.RolesAggregate.RolesEntity;

namespace EquityAfia.UserManagement.Domain.UserAggregate.UsersEntities
{
    public class Practitioner : User
    {
        public string LicenseNumber { get; set; }
        public PractitionerType PractitionerType { get; set; }
    }

}
