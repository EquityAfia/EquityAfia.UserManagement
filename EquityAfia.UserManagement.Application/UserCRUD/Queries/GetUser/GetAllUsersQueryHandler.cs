using AutoMapper;
using EquityAfia.UserManagement.Application.Interfaces;
using EquityAfia.UserManagement.Domain.UserAggregate.UsersEntities; // Assuming User entity namespace
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Application.UserCRUD.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _userRepository.GetAllUsersAsync();

                return users;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An unexcpected error occoured while executing get all users query handler", ex);
            }
        }
    }
}
