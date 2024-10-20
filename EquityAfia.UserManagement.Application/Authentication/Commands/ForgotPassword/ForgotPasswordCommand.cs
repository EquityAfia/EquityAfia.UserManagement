
using EquityAfia.UserManagement.Contracts.AuthenticationDTOs.ForgotPasswordDTOs;
using MediatR;

namespace EquityAfia.UserManagement.Application.Authentication.Commands.ForgotPassword
{
    public class ForgotPasswordCommand : IRequest<ForgotPasswordResponse>
    {
        public ForgotPasswordRequest ForgotPasswordRequest { get; set; }
        public ForgotPasswordCommand(ForgotPasswordRequest user)
        {
            ForgotPasswordRequest = user;
        }
    }
}
