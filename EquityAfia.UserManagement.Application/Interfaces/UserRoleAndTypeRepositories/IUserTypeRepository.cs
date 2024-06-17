using EquityAfia.UserManagement.Contracts.UserRoleAndTypeManagement.UserType;
using EquityAfia.UserManagement.Domain.RolesAndTypesAggregate.RolesAndTypesEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Application.Interfaces.UserRoleAndTypeRepositories
{
    public interface IUserTypeRepository
    {
        Task<List<UserType>> GetAllUserTypesAsync();
        Task<UserType> GetUserTypeByNameAsync(string userTypeName);
        Task<UserType> GetUserTypeByIdAsync(Guid id);
        Task<Guid> AddUserTypeAsync(UserType userType);
        Task<bool> UpdateUserTypeAsync(Guid userTypeId, UserTypeRequest userTypeDto);
        Task<bool> DeleteUserTypeAsync(Guid userTypeId);
    }
}
