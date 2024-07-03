using EquityAfia.UserManagement.Application.Interfaces.UserRoleAndTypeRepositories;
using EquityAfia.UserManagement.Contracts.UserRoleAndTypeManagementDTOs.UserTypeDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Application.UserTypesManagement.Commands.DeleteUserType
{
    public class DeleteUserTypeCommandHandler : IRequestHandler<DeleteUserTypeCommand, UserTypeResponse>
    {
        private readonly IUserTypeRepository _userTypeRepository;
        public DeleteUserTypeCommandHandler(IUserTypeRepository userTypeRepository)
        {
            _userTypeRepository = userTypeRepository;
        }
        public async Task<UserTypeResponse> Handle(DeleteUserTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userType = await _userTypeRepository.GetUserTypeByIdAsync(request.TypeId);
                if (userType == null)
                {
                    throw new Exception($"User type with the ID '{request.TypeId}' does not exist");
                }

                await _userTypeRepository.DeleteUserTypeAsync(request.TypeId);

                var response = new UserTypeResponse
                {
                    Message = "User Type deleted successfully",
                    TypeId = request.TypeId,
                };

                return response;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An unexpected error occoured while executing delete user type command handler", ex);

            }
        }
    }
}
