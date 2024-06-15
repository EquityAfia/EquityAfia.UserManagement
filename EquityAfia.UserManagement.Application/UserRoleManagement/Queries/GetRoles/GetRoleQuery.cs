using EquityAfia.UserManagement.Domain.RolesAggregate.RolesEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Application.UserRoleManagement.Queries.GetRoles
{
    public class GetRoleQuery : IRequest<List<Role>>
    {
    }
}
