using MediatR;
using EquityAfia.UserManagement.Contracts.UserCRUD.GetUser;

namespace EquityAfia.UserManagement.Application.UserCRUD.Queries.GetUser
{
    public class GetUserCommand : IRequest<GetUserResponse>
    {
        public string Email { get; set; }

        public GetUserCommand(string email)
        {
            Email = email;
        }
    }
}
