﻿using EquityAfia.UserManagement.Application.Interfaces.UserRoleAndTypeRepositories;
using EquityAfia.UserManagement.Contracts.UserRoleAndTypeManagement.UserRole;
using EquityAfia.UserManagement.Domain.RolesAggregate.RolesEntity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Application.UserRoleManagement.Commands.UpdateRole;

public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, UserRoleResponse>
{
    private readonly IRoleRepository _roleRepository;

    public UpdateRoleCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<UserRoleResponse> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var existingRole = await _roleRepository.GetRoleByIdAsync(request.RoleId);
        if (existingRole == null)
        {
            throw new Exception($"Role with ID '{request.RoleId}' does not exist.");
        }

        var updatedRole = await _roleRepository.UpdateRoleAsync(request.RoleId, request.NewRoleName);

        var response = new UserRoleResponse
        {
            RoleId = updatedRole.RoleId, 
            RoleName = updatedRole.RoleName
        };

        return response;
    }
}