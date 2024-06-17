using EquityAfia.UserManagement.Contracts.UserRoleAndTypeManagement.UserRole;
using EquityAfia.UserManagement.Contracts.UserRoleAndTypeManagement.UserType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Application.UserTypesManagement.Commands.UpdateUserType
{
    public class UpdateUserTypeCommand : IRequest<UserTypeResponse>
    {
        public UserTypeRequest TypeRequest { get; set; }
        public Guid TypeId { get; set; }

        public UpdateUserTypeCommand(UserTypeRequest userTypeRequest, Guid typeId)
        {
            TypeRequest = userTypeRequest;
            TypeId = typeId;

        }
    }
}
