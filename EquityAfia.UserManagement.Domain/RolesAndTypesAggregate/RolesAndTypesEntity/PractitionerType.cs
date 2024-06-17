using EquityAfia.UserManagement.Domain.UserAggregate.UsersEntities;
using System;
using System.ComponentModel.DataAnnotations;

namespace EquityAfia.UserManagement.Domain.RolesAndTypesAggregate.RolesAndTypesEntity
{
    public class PractitionerType
    {
        [Key]
        public Guid Id { get; set; }

        public Guid PractitionerId { get; set; }
        public Practitioner Practitioner { get; set; }

        public Guid TypeId { get; set; }
        public UserType Type { get; set; }

        [Required]
        public string TypeName { get; set; }
    }
}
