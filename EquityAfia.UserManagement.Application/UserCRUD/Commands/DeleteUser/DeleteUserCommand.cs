
using EquityAfia.UserManagement.Contracts.UserCrudDTOs.DeleteUserDTOs;
using MediatR;

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
