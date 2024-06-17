using EquityAfia.UserManagement.Domain.UserAggregate.UsersEntities;
using System;
using System.ComponentModel.DataAnnotations;

namespace EquityAfia.UserManagement.Domain.RolesAndTypesAggregate.RolesAndTypesEntity;

public class UserRole
{
    [Key]
    public Guid Id { get; set; }
    public User User { get; set; }

    public Guid RoleId { get; set; }
    public Role Role { get; set; }
}
