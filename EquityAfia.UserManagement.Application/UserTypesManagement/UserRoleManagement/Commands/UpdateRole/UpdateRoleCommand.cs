using MediatR;
using EquityAfia.UserManagement.Contracts.UserRoleAndTypeManagement.UserRole;

namespace EquityAfia.UserManagement.Application.UserRoleManagement.Commands.UpdateRole;

public class UpdateRoleCommand : IRequest<UserRoleResponse>
{
    public Guid RoleId { get; set; }
    public string NewRoleName { get; set; }

    public UpdateRoleCommand(Guid roleId, string newRoleName)
    {
        RoleId = roleId;
        NewRoleName = newRoleName;
    }
}
