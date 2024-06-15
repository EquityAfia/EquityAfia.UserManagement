﻿using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EquityAfia.UserManagement.Contracts.UserRoleAndTypeManagement.UserRole;
using EquityAfia.UserManagement.Application.Interfaces.UserRoleAndTypeRepositories;
using EquityAfia.UserManagement.Domain.RolesAggregate.RolesEntity;

namespace EquityAfia.UserManagement.Application.UserRoleManagement.Commands.AddRole
{
    public class AddRoleCommandHandler : IRequestHandler<AddRoleCommand, UserRoleResponse>
    {
        private readonly IRoleRepository _roleRepository;

        public AddRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<UserRoleResponse> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetRoleByNameAsync(request.UserRoleRequest.RoleName);
            if (role != null)
            {
                throw new Exception("Role with that Name already exists");
            }

            var roleToAdd = new Role
            {
                RoleName = request.UserRoleRequest.RoleName, 
                
            };

            await _roleRepository.AddRoleAsync(roleToAdd); 

            var roleResponse = new UserRoleResponse
            {
                RoleName = roleToAdd.RoleName,
                
            };

            return roleResponse;
        }
    }
}