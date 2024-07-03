using EquityAfia.UserManagement.Contracts.AuthenticationDTOs.ForgotPasswordDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
