
using EquityAfia.UserManagement.Domain.UserAggregate.UsersEntities;
using EquityAfia.UserManagement.Application.Interfaces;
using EquityAfia.UserManagement.Application.Interfaces.UserRoleAndTypeRepositories;
using EquityAfia.UserManagement.Domain.RolesAndTypesAggregate.RolesAndTypesEntity;

namespace EquityAfia.UserManagement.Application.Authentication.Common
{
    public static class UserRolesAssigner
    {
        public static async Task AssignRolesToUserAsync(IUserRepository userRepository, IRoleRepository roleRepository, User user, List<string> roleNames)
        {
            try
            {
                if (roleNames != null && roleNames.Count > 0)
                {
                    foreach (var roleName in roleNames)
                    {
                        var role = await roleRepository.GetRoleByNameAsync(roleName);
                        if (role == null)
                        {
                            throw new Exception($"Role '{roleName}' not found.");
                        }

                        user.UserRoles.Add(new UserRole
                        {
                            Id = Guid.NewGuid(),
                            User = user,
                            RoleId = role.RoleId,
                            Role = role
                        });
                    }
                }

                await userRepository.AddUserAsync(user);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An unexcpected error occoured while executing assign role to user", ex);
            }
        }
    }
}
