﻿using EquityAfia.UserManagement.Contracts.UserRoleAndTypeManagement.UserRole;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Application.UserRoleManagement.Commands.DeleteRole;

public class DeleteRoleCommand : IRequest<UserRoleResponse>
{
    public Guid RoleId { get; set; }
    public DeleteRoleCommand(Guid roleId)
    {
        RoleId = roleId;
    }
}
