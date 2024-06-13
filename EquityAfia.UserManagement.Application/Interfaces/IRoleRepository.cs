using EquityAfia.UserManagement.Domain.RolesAggregate.RolesEntity;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Application.Interfaces
{
    public interface IRoleRepository
    {
        Task<Role> GetRoleByIdAsync(int roleId);
        Task<Role> GetRoleByNameAsync(string roleName);
        Task AddRoleAsync(Role role);   
        Task DeleteRoleAsync(int roleId); 
        
    }
}
