using EquityAfia.UserManagement.Application.Interfaces.UserRoleAndTypeRepositories;
using EquityAfia.UserManagement.Contracts.UserRoleAndTypeManagementDTOs.UserRoleDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Application.UserRoleManagement.Commands.DeleteRole;

public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, UserRoleResponse>
{
    private readonly IRoleRepository _roleRepository;

    public DeleteRoleCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<UserRoleResponse> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var role = await _roleRepository.GetRoleByIdAsync(request.RoleId);
            if (role == null)
            {
                throw new Exception($"Role with Id '{request.RoleId}' does not exist");
            }

            await _roleRepository.DeleteRoleAsync(request.RoleId);

            var response = new UserRoleResponse
            {
                Message = "Role has been deleted successfully"
            };

            return response;
        }
        catch (Exception ex)
        {
            throw new ApplicationException(ex.ToString());
        }
    }
}
