using EquityAfia.UserManagement.Contracts.UserCRUD.UpdateUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Application.UserCRUD.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<UpdateUserResponse>
    {
        public string? IdNumber { get; set; }
        public string? Email { get; set; }
        public UpdateUserRequest? UpdateUserRequest { get; set; }

        public UpdateUserCommand(UpdateUserRequest updateUserRequest)
        {
            UpdateUserRequest = updateUserRequest;
        }
    }
}
