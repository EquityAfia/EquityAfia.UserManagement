using EquityAfia.UserManagement.Application.Interfaces.UserRoleAndTypeRepositories;
using EquityAfia.UserManagement.Contracts.UserRoleAndTypeManagement.UserRole;
using EquityAfia.UserManagement.Contracts.UserRoleAndTypeManagement.UserType;
using EquityAfia.UserManagement.Domain.RolesAndTypesAggregate.RolesAndTypesEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Application.UserTypesManagement.Commands.AddUserType
{
    public class AddUserTypeCommandHandler : IRequestHandler<AddUserTypeCommand, UserTypeResponse>
    {
        private readonly IUserTypeRepository _userTypeRepository;
        public AddUserTypeCommandHandler(IUserTypeRepository userTypeRepository)
        {
            _userTypeRepository = userTypeRepository;
        }

        public async Task<UserTypeResponse> Handle(AddUserTypeCommand request, CancellationToken cancellationToken)
        {
            var Request = request.UserTypeRequest;

            var userType = await _userTypeRepository.GetUserTypeByNameAsync(Request.TypeName);
            if (userType != null)
            {
                throw new Exception($"User type {Request.TypeName} already exist");
            }

            var typeToAdd = new UserType
            {
                TypeName = Request.TypeName,
            };

            await _userTypeRepository.AddUserTypeAsync(typeToAdd);

            var addedRole = await _userTypeRepository.GetUserTypeByNameAsync(typeToAdd.TypeName);

            var response = new UserTypeResponse
            {
                Message = "Role added successfully",
                TypeId = addedRole.Id,
                TypeName = Request.TypeName
            };

            return response;
        }
    }
}
