using EquityAfia.UserManagement.Contracts.UserRoleAndTypeManagement.UserType;
using EquityAfia.UserManagement.Domain.RolesAndTypesAggregate.RolesAndTypesEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Application.Interfaces.UserRoleAndTypeRepositories
{
    public interface IUserTypeRepository
    {
        Task<List<UserType>> GetAllUserTypesAsync();
        Task<UserType> GetUserTypeByIdAsync(int userTypeId);
        Task<int> AddUserTypeAsync(UserTypeRequest userTypeDto);
        Task<bool> UpdateUserTypeAsync(int userTypeId, UserTypeRequest userTypeDto);
        Task<bool> DeleteUserTypeAsync(int userTypeId);
    }
}
