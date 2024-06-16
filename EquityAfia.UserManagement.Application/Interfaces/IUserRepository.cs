

using EquityAfia.UserManagement.Contracts.UserCRUD.UpdateUser;
using EquityAfia.UserManagement.Domain.UserAggregate.UsersEntities;

namespace EquityAfia.UserManagement.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByEmailOrIdNumberAsync(string? idNumber, string? email);
        Task<User> GetUserByIdAsync(string idNumber);
        Task<User> GetUserByEmailAsync(string email);
        Task AddUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task DeleteUserAsync(string idNumber, string email);
    }
}
