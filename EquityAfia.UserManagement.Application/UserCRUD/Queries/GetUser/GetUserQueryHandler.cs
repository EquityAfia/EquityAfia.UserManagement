using EquityAfia.UserManagement.Application.Interfaces;
using EquityAfia.UserManagement.Contracts.UserCRUD.GetUser;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Application.UserCRUD.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserResponse>
    {
        private readonly IUserRepository _userRepository;

        // Constructor should only include dependencies that can be injected
        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var Request = request.GetUserRequest;
            // Retrieve user by email or ID number asynchronously
            var user = await _userRepository.GetUserByEmailOrIdNumberAsync(Request.Email, Request.IdNumber); 
            if (user == null)
            {
                throw new ApplicationException("User not found");
            }

            // Map the user entity to the GetUserResponse DTO
            var response = new GetUserResponse
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                IdNumber = user.IdNumber,
                Location = user.Location,
                DateOfBirth = user.DateOfBirth,
                UserType = user.UserType
            };

            return response;
        }
    }
}
