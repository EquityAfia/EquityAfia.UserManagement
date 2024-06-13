
using EquityAfia.UserManagement.Application.Interfaces;
using EquityAfia.UserManagement.Domain.RolesAggregate.RolesEntity;
using EquityAfia.UserManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Method to fetch a role by its ID
        public async Task<Role> GetRoleByIdAsync(int roleId)
        {
            return await _context.Roles.FindAsync(roleId);
        }

        // Method to fetch a role by its name
        public async Task<Role> GetRoleByNameAsync(string roleName)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == roleName);
        }

        // Method to add a new role
        public async Task AddRoleAsync(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
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

        
    }
}
