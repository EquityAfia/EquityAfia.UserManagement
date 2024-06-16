
using AutoMapper;
using EquityAfia.UserManagement.Application.Interfaces;
using EquityAfia.UserManagement.Contracts.UserCRUD.UpdateUser;
using EquityAfia.UserManagement.Domain.UserAggregate.UsersEntities;
using EquityAfia.UserManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EquityAfia.UserManagement.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByEmailOrIdNumberAsync(string email, string idNumber)
        {
            // Example method to get user by either email or ID number
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email || u.IdNumber == idNumber);
        }

        public async Task<User> GetUserByIdAsync(string idNumber)
        {
            return await _context.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.IdNumber == idNumber);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUserAsync(string idNumber, string email)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email || u.IdNumber == idNumber);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
