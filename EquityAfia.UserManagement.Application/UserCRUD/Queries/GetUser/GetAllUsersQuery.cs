using MediatR;
using EquityAfia.UserManagement.Contracts.UserCRUD.GetUser;
using System.Collections.Generic;
using EquityAfia.UserManagement.Domain.UserAggregate.UsersEntities;

namespace EquityAfia.UserManagement.Application.UserCRUD.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {
    }
}
