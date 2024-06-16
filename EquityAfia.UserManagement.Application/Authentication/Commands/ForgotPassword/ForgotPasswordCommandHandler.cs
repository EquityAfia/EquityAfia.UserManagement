using EquityAfia.UserManagement.Application.Interfaces;
using EquityAfia.UserManagement.Contracts.Authentication.Forgotpassword;
using MediatR;

namespace EquityAfia.UserManagement.Application.Authentication.Commands.ForgotPassword
{
    public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, ForgotPasswordResponse>
    {
        private readonly IUserRepository _repository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public ForgotPasswordCommandHandler(IUserRepository repository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _repository = repository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<ForgotPasswordResponse> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Request = request.ForgotPasswordRequest;
                var user = await _repository.GetUserByEmailAsync(Request.Email);

                if (user == null)
                {
                    throw new UnauthorizedAccessException("User not found");
                }

                var resetToken = _jwtTokenGenerator.GenerateRandomToken(user);

                user.ResetToken = resetToken;

                user.SetResetToken(resetToken);

                await _repository.UpdateUserAsync(user);

                // Send the token to the email

                var response = new ForgotPasswordResponse
                {
                    Email = user.Email,
                    ResetCode = resetToken
                };

                return response;
            } catch (Exception ex)
            {
                throw new ApplicationException("An unexpected error occoured while executing forgot password command handler", ex);
            }
        }
    }
}
