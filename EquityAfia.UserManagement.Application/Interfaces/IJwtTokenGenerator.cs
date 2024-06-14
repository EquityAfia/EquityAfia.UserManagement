
using EquityAfia.UserManagement.Domain.UserAggregate.UsersEntities;

namespace EquityAfia.UserManagement.Application.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);

        string GenerateRandomToken(User user);
    }
}

