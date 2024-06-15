using EquityAfia.UserManagement.Domain.RolesAggregate.RolesEntity;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Application.Interfaces.UserRoleAndTypeRepositories;

public interface IRoleRepository
{
    
    Task<List<Role>> GetAllRoles();
    Task<Role> GetRoleByIdAsync(int roleId);

    Task<Role> GetRoleByNameAsync(string roleName);
    Task<int> AddRoleAsync(Role role);
    Task<Role> UpdateRoleAsync(int roleId, string newRoleName);

    Task DeleteRoleAsync(int roleId);

}
