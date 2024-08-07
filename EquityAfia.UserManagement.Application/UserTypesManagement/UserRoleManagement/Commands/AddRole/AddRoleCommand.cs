﻿using EquityAfia.UserManagement.Contracts.UserRoleAndTypeManagementDTOs.UserRoleDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Application.UserRoleManagement.Commands.AddRole;

public class AddRoleCommand : IRequest<UserRoleResponse>
{
    public UserRoleRequest UserRoleRequest { get; set; }
    public AddRoleCommand(UserRoleRequest userRoleRequest)
    {
        UserRoleRequest = userRoleRequest;
    }
}
