using EquityAfia.UserManagement.Domain.RolesAggregate.RolesEntity;
using System;
using System.ComponentModel.DataAnnotations;

namespace EquityAfia.UserManagement.Domain.UserAggregate.UsersEntities
{
    public class UserRole
    {
        [Key]
        public Guid Id { get; set; }
        public User User { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
