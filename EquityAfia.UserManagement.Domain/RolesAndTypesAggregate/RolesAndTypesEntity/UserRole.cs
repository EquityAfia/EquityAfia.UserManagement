using EquityAfia.UserManagement.Domain.UserAggregate.UsersEntities;
using System;
using System.ComponentModel.DataAnnotations;

namespace EquityAfia.UserManagement.Domain.RolesAndTypesAggregate.RolesAndTypesEntity
{
    public class UserRole
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public User User { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
