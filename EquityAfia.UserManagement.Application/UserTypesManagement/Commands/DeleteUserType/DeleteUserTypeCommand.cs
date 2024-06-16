using EquityAfia.UserManagement.Contracts.UserRoleAndTypeManagement.UserType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Application.UserTypesManagement.Commands.DeleteUserType
{
    public class DeleteUserTypeCommand : IRequest<UserTypeResponse>
    {
        public int TypeId { get; set; }
        public DeleteUserTypeCommand(int typeId)
        {
            TypeId = typeId;
        }
    }
}
