using EquityAfia.SharedContracts;
using EquityAfia.UserManagement.Application.Interfaces;
using EquityAfia.UserManagement.Contracts.AuthenticationDTOs.ForgotPasswordDTOs;
using MassTransit;
using MediatR;

namespace EquityAfia.UserManagement.Application.Authentication.Commands.ForgotPassword
{
    public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, ForgotPasswordResponse>
    {
        private readonly IUserRepository _repository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IPublishEndpoint _publishEndpoint;
        public ForgotPasswordCommandHandler(IUserRepository repository, IJwtTokenGenerator jwtTokenGenerator, IPublishEndpoint publishEndpoint)
        {
            _repository = repository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _publishEndpoint = publishEndpoint;
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

                var forgotPasswordEvent = new UserForgotPassword
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Token = user.ResetToken
                };

                await _publishEndpoint.Publish(forgotPasswordEvent);

                return response;
            } catch (Exception ex)
            {
                throw new ApplicationException(ex.ToString());
            }
        }
    }
}
