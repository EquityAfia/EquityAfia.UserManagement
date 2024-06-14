using EquityAfia.UserManagement.Domain.UserAggregate.UsersEntities;
using System;
using System.ComponentModel.DataAnnotations;

namespace EquityAfia.UserManagement.Domain.RolesAggregate.RolesEntity
{
    public class PractitionerType
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        // Foreign key for Practitioner/User
        public Guid PractitionerId { get; set; }
        public Practitioner Practitioner { get; set; }

        // Foreign key for UserType
        public int TypeId { get; set; }
        public UserType Type { get; set; }

        [Required]
        public string TypeName { get; set; }
    }
}
