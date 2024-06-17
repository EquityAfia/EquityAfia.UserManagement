using EquityAfia.UserManagement.Domain.RolesAndTypesAggregate.RolesAndTypesEntity;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Application.Interfaces.UserRoleAndTypeRepositories;

public interface IRoleRepository
{
    
    Task<List<Role>> GetAllRoles();
    Task<Role> GetRoleByIdAsync(Guid roleId);

    Task<Role> GetRoleByNameAsync(string roleName);
    Task<Guid> AddRoleAsync(Role role);
    Task<Role> UpdateRoleAsync(Guid roleId, string newRoleName);

    Task DeleteRoleAsync(Guid roleId);

}
