using EquityAfia.UserManagement.Application.Common;
using EquityAfia.UserManagement.Application.Interfaces;
using EquityAfia.UserManagement.Contracts.Authentication.ResetPassword;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Application.Authentication.Commands.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, ResetPasswordResponse>
    {
        private readonly IUserRepository _userRepository;
        public ResetPasswordCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResetPasswordResponse> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var Request = request.ResetPasswordRequest;

            var user = await _userRepository.GetUserByEmailAsync(Request.Email);

            if(user == null)
            {
                throw new UnauthorizedAccessException("User not found");
            }

            var isResetCodeValid = BCrypt.Net.BCrypt.Verify(Request.ResetCode, user.ResetToken);

            if (!isResetCodeValid)
            {
                throw new UnauthorizedAccessException("Reset code is not valid");
            }

            var newPassword = Request.NewPassword;
            user.ChangePassword(newPassword);

            user.ClerResetToken(user);

            await _userRepository.UpdateUserAsync(user);

            var response = new ResetPasswordResponse
            {
                Message = "Password reset successfully"
            };

            return response;
        }
    }
}
