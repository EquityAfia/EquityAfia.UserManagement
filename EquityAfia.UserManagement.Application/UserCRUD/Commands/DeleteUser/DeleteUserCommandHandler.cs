﻿using EquityAfia.UserManagement.Application.Interfaces;
using EquityAfia.UserManagement.Contracts.UserCrudDTOs.DeleteUserDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Application.UserCRUD.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteUserResponse>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<DeleteUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetUserByEmailOrIdNumberAsync(request.Email, request.IdNumber);
                if (user == null)
                {
                    throw new Exception("User not found!!");
                }

               // await _userRepository.DeleteUserAsync(request.Email, request.IdNumber);

               user.IsDeleted = true;
               await _userRepository.UpdateUserAsync(user);

                var response = new DeleteUserResponse
                {
                    Message = "User deleted successfully",
                    IdNumber = request.IdNumber,
                    Email = request.Email,
                };

                return response;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.ToString());
            }
        }
    }
}
