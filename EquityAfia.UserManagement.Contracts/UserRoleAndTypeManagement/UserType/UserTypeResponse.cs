using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Contracts.UserRoleAndTypeManagement.UserType;

public class UserTypeResponse
{
    public string? Message { get; set; }
    public Guid? TypeId { get; set; }
    public string? TypeName { get; set; }
}
