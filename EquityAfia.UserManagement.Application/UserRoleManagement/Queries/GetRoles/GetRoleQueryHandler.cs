
using EquityAfia.UserManagement.Application.Interfaces.UserRoleAndTypeRepositories;
using EquityAfia.UserManagement.Domain.RolesAndTypesAggregate.RolesAndTypesEntity;
using MediatR;

namespace EquityAfia.UserManagement.Application.UserRoleManagement.Queries.GetRoles
{
    public class GetRoleQueryHandler : IRequestHandler<GetRoleQuery, List<Role>>
    {
        private readonly IRoleRepository _roleRepository;

        public GetRoleQueryHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public Task<List<Role>> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {
            var roles = _roleRepository.GetAllRoles();
            if (roles == null)
            {
                throw new Exception("The list of roles is empty");
            }

            return roles;
        }
    }
}
