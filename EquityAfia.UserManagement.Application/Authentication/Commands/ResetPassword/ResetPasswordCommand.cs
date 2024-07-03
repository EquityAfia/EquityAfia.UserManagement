using EquityAfia.UserManagement.Contracts.AuthenticationDTOs.ResetPasswordDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Application.Authentication.Commands.ResetPassword
{
    public class ResetPasswordCommand : IRequest<ResetPasswordResponse>
    {
        public ResetPasswordRequest ResetPasswordRequest { get; set; }
        public ResetPasswordCommand(ResetPasswordRequest request)
        {
            ResetPasswordRequest = request;
        }
    }
}
