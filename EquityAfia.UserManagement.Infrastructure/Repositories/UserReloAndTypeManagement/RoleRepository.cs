using EquityAfia.UserManagement.Application.Interfaces.UserRoleAndTypeRepositories;
using EquityAfia.UserManagement.Domain.RolesAndTypesAggregate.RolesAndTypesEntity;
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
        try
        {
            return await _context.Roles.ToListAsync();
        }
        catch (Exception ex)
        {
            throw new ApplicationException("An unexpected error occurred while getting all user roles", ex);
        }
    }

    // Method to fetch a role by its ID
    public async Task<Role> GetRoleByIdAsync(int roleId)
    {
        try
        {
            return await _context.Roles.FindAsync(roleId);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("An unexpected error occurred while getting role by Id", ex);
        }
    }

    // Method to fetch a role by its name
    public async Task<Role> GetRoleByNameAsync(string roleName)
    {
        try
        {
            return await _context.Roles
                .FirstOrDefaultAsync(r => r.RoleName == roleName);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("An unexpected error occurred getting user role by name", ex);
        }
    }

    // Method to add a new role
    public async Task<int> AddRoleAsync(Role role)
    {
        try
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();

            return role.RoleId;
        }
        catch (Exception ex)
        {
            throw new ApplicationException("An unexpected error occurred while adding a user role", ex);
        }
    }

    public async Task<Role> UpdateRoleAsync(int roleId, string newRoleName)
    {
        try
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
        catch (Exception ex)
        {
            throw new ApplicationException("An unexpected error occurred while updating user role", ex);
        }
    }


    // Method to delete a role by ID
    public async Task DeleteRoleAsync(int roleId)
    {
        try
        {
            var role = await _context.Roles.FindAsync(roleId);
            if (role != null)
            {
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("An unexpected error occurred while deleting user role", ex);
        }
    }

}
