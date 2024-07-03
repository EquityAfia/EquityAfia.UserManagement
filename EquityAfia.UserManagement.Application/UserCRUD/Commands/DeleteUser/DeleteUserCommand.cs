using EquityAfia.UserManagement.Contracts.UserCrudDTOs.DeleteUserDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Application.UserCRUD.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<DeleteUserResponse>
    {
        public string IdNumber { get; set; }
        public string Email { get; set; }

        public DeleteUserCommand()
        {
        }
    }
}
