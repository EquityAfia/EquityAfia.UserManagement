using EquityAfia.UserManagement.Contracts.UserRoleAndTypeManagementDTOs.UserTypeDTOs;
using MediatR;

namespace EquityAfia.UserManagement.Application.UserTypesManagement.Commands.UpdateUserType
{
    public class UpdateUserTypeCommand : IRequest<UserTypeResponse>
    {
        public UserTypeRequest TypeRequest { get; set; }
        public Guid TypeId { get; set; }

        public UpdateUserTypeCommand(UserTypeRequest userTypeRequest, Guid typeId)
        {
            TypeRequest = userTypeRequest;
            TypeId = typeId;

        }
    }
}
