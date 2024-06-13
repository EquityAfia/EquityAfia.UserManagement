using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EquityAfia.UserManagement.Domain.RolesAggregate.RolesEntity;

public class Role
{
  //  [Key]
    public int RoleId { get; set; }

    [Required]
    public string RoleName { get; set; }

    // Navigation property for UserRole
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
