using EquityAfia.UserManagement.Application.Interfaces.UserRoleAndTypeRepositories;
using EquityAfia.UserManagement.Domain.RolesAggregate.RolesEntity;
using EquityAfia.UserManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Infrastructure.Repositories.UserReloAndTypeManagement;

public class RoleRepository : IRoleRepository
{
    private readonly ApplicationDbContext _context;

    public RoleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Role>> GetAllRoles()
    {
        return await _context.Roles.ToListAsync();
    }

    // Method to fetch a role by its ID
    public async Task<Role> GetRoleByIdAsync(int roleId)
    {
        return await _context.Roles.FindAsync(roleId);
    }

    // Method to fetch a role by its name
    public async Task<Role> GetRoleByNameAsync(string roleName)
    {
        return await _context.Roles
            .FirstOrDefaultAsync(r => r.RoleName == roleName);
    }

    // Method to add a new role
    public async Task<int> AddRoleAsync(Role role)
    {
        _context.Roles.Add(role);
        await _context.SaveChangesAsync();
        return role.RoleId; 
    }


    // Method to delete a role by ID
    public async Task DeleteRoleAsync(int roleId)
    {
        var role = await _context.Roles.FindAsync(roleId);
        if (role != null)
        {
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Role> UpdateRoleAsync(int roleId, string newRoleName)
    {
        var role = await _context.Roles.FindAsync(roleId);
        if (role == null)
        {
            throw new Exception($"Role with ID '{roleId}' does not exist.");
        }

        role.RoleName = newRoleName;
        await _context.SaveChangesAsync();

        return role;
    }

}
