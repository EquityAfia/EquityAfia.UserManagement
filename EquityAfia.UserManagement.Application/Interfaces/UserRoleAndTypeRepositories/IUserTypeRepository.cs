using EquityAfia.UserManagement.Contracts.UserRoleAndTypeManagement.UserType;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Application.Interfaces.UserRoleAndTypeRepositories
{
    public interface IUserTypeRepository
    {
        Task<List<UserTypeRequest>> GetAllUserTypesAsync();
        Task<UserTypeRequest> GetUserTypeByIdAsync(int userTypeId);
        Task<int> AddUserTypeAsync(UserTypeRequest userTypeDto);
        Task<bool> UpdateUserTypeAsync(int userTypeId, UserTypeRequest userTypeDto);
        Task<bool> DeleteUserTypeAsync(int userTypeId);
    }
}
