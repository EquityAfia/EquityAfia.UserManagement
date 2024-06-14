using MediatR;
using EquityAfia.UserManagement.Contracts.UserCRUD.GetUser;

namespace EquityAfia.UserManagement.Application.UserCRUD.Queries.GetUser
{
    public class GetUserCommand : IRequest<GetUserResponse>
    {
        public GetUserRequest GetUserRequest { get; set; }

        // Constructor to initialize the command with either email or ID number
        public GetUserCommand(GetUserRequest getUserRequest = null)
        {
            GetUserRequest = getUserRequest;
        }
    }
}
