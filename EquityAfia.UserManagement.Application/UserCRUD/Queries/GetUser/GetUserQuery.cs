using MediatR;
using EquityAfia.UserManagement.Contracts.UserCRUD.GetUser;

namespace EquityAfia.UserManagement.Application.UserCRUD.Queries.GetUser
{
    public class GetUserQuery : IRequest<GetUserResponse>
    {
        public GetUserRequest GetUserRequest { get; set; }

        public GetUserQuery(GetUserRequest getUserRequest = null)
        {
            GetUserRequest = getUserRequest;
        }
    }
}
