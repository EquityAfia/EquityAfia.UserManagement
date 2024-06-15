using EquityAfia.UserManagement.Contracts.UserRoleAndTypeManagement.UserType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Application.UserTypesManagement.Commands.AddUserType
{
    public class AddUserTypeCommand : IRequest<UserTypeResponse>
    {
        public UserTypeRequest UserTypeRequest { get; set; }
        public AddUserTypeCommand(UserTypeRequest userTypeRequest)
        {
            UserTypeRequest = userTypeRequest;
        }
    }
}
