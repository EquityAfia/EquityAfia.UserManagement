using MediatR;
using EquityAfia.UserManagement.Contracts.UserCRUD.GetUser;

namespace EquityAfia.UserManagement.Application.UserCRUD.Queries.GetUser
{
    public class GetUserCommand : IRequest<GetUserResponse>
    {
        public string Email { get; set; }
        public string IdNumber { get; set; }

        // Constructor to initialize the command with either email or ID number
        public GetUserCommand(string email = null, string idNumber = null)
        {
            Email = email;
            IdNumber = idNumber;
        }
    }
}
