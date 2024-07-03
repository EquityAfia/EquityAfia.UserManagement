using EquityAfia.UserManagement.Domain.RolesAndTypesAggregate.RolesAndTypesEntity;
using MediatR;

namespace EquityAfia.UserManagement.Application.UserTypesManagement.Queries.GetUserTypes
{
    public class GetUserTypeQuery : IRequest<List<UserType>>
    {
    }
}
