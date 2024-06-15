using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Contracts.UserRoleAndTypeManagement.UserRole
{
    public class UserRoleResponse
    {
        public int? RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? Message { get; set; }
    }
}
