using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Contracts.UserRoleAndTypeManagement.UserRole
{
    public class UserRoleResponse
    {
        public string? Message { get; set; }
        public Guid? RoleId { get; set; }
        public string? RoleName { get; set; }
    }
}
