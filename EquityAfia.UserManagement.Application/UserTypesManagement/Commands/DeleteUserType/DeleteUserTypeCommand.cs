using EquityAfia.UserManagement.Contracts.UserRoleAndTypeManagementDTOs.UserTypeDTOs;
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
        public Guid TypeId { get; set; }
        public DeleteUserTypeCommand(Guid typeId)
        {
            TypeId = typeId;
        }
    }
}
