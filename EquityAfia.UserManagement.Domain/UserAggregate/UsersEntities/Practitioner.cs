using EquityAfia.UserManagement.Domain.RolesAndTypesAggregate.RolesAndTypesEntity;

namespace EquityAfia.UserManagement.Domain.UserAggregate.UsersEntities
{
    public class Practitioner : User
    {
        // Primary key of type Guid
        public string LicenseNumber { get; set; }
        public ICollection<PractitionerType> PractitionerTypes { get; set; } = new List<PractitionerType>();
    }

}
