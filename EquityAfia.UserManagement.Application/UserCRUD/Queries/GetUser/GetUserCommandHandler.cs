﻿using EquityAfia.UserManagement.Application.Interfaces;
using EquityAfia.UserManagement.Contracts.UserCRUD.GetUser;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Application.UserCRUD.Queries.GetUser
{
    public class GetUserCommandHandler : IRequestHandler<GetUserCommand, GetUserResponse>
    {
        private readonly IUserRepository _userRepository;

        // Constructor should only include dependencies that can be injected
        public GetUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserResponse> Handle(GetUserCommand request, CancellationToken cancellationToken)
        {
            // Retrieve user by email or ID number asynchronously
            var user = await _userRepository.GetUserByEmailOrIdNumberAsync(request.Email, request.IdNumber); 
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
