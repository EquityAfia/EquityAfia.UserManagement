using EquityAfia.SharedContracts;
using EquityAfia.UserManagement.Application.Interfaces;
using MassTransit;

namespace EquityAfia.UserManagement.Application.EventsRequestsHandlers
{
    public class UserExistsRequestHandler : IConsumer<UserExists>
    {
        public readonly IUserRepository _userRepository;
        public readonly UserExists _userExists;

        public UserExistsRequestHandler(IUserRepository _userRepository, UserExists userExists)
        {
            _userRepository = _userRepository;
            _userExists = userExists;
        }
        public async Task Consume(ConsumeContext<UserExists> context)
        {
            var user = await _userRepository.GetUserByIdAsync(_userExists.IdNumber);

            if (user is null)
            {
                throw new Exception("User not found");
            }

            var response = new UserExists
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                IdNumber = user.IdNumber,
            };

            return;
        }
    }
}
