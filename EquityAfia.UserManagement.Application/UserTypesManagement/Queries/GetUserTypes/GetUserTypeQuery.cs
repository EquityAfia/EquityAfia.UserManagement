using EquityAfia.UserManagement.Contracts.UserRoleAndTypeManagement.UserType;
using EquityAfia.UserManagement.Domain.RolesAndTypesAggregate.RolesAndTypesEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Application.UserTypesManagement.Queries.GetUserTypes
{
    public class GetUserTypeQuery : IRequest<List<UserType>>
    {
    }
}
