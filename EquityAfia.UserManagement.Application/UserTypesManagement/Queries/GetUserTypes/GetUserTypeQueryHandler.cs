using EquityAfia.UserManagement.Application.Interfaces.UserRoleAndTypeRepositories;
using EquityAfia.UserManagement.Contracts.UserRoleAndTypeManagement.UserType;
using EquityAfia.UserManagement.Domain.RolesAndTypesAggregate.RolesAndTypesEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Application.UserTypesManagement.Queries.GetUserTypes
{
    public class GetUserTypeQueryHandler : IRequestHandler<GetUserTypeQuery, List<UserType>>
    {
        private readonly IUserTypeRepository _userTypeRepository;

        public GetUserTypeQueryHandler(IUserTypeRepository userTypeRepository)
        {
            _userTypeRepository = userTypeRepository;
        }

        public async Task<List<UserType>> Handle(GetUserTypeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var userTypes = await _userTypeRepository.GetAllUserTypesAsync();
                if (userTypes == null)
                {
                    throw new Exception("The list is emply");
                }

                return userTypes;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An unexpected error occoured while executing get user type command handler", ex);

            }
        }
    }
}
