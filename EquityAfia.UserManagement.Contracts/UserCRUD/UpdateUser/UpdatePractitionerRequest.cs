using EquityAfia.UserManagement.Domain.RolesAndTypesAggregate.RolesAndTypesEntity;
using System;

namespace EquityAfia.UserManagement.Contracts.UserCRUD.UpdateUser
{
    public class UpdatePractitionerRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }
    }
}
