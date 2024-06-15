using AutoMapper;
using EquityAfia.UserManagement.Application.Interfaces.UserRoleAndTypeRepositories;
using EquityAfia.UserManagement.Contracts.UserRoleAndTypeManagement.UserType;
using EquityAfia.UserManagement.Domain.RolesAggregate.RolesEntity;
using EquityAfia.UserManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EquityAfia.UserManagement.Infrastructure.Repositories.UserReloAndTypeManagement
{
    public class UserTypeRepository : IUserTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserTypeRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<UserTypeRequest>> GetAllUserTypesAsync()
        {
            var userTypes = await _dbContext.UserTypes
                .Select(ut => _mapper.Map<UserTypeRequest>(ut))
                .ToListAsync();

            return userTypes;
        }

        public async Task<UserTypeRequest> GetUserTypeByIdAsync(int userTypeId)
        {
            var userType = await _dbContext.UserTypes
                .Where(ut => ut.Id == userTypeId)
                .FirstOrDefaultAsync();

            return _mapper.Map<UserTypeRequest>(userType);
        }

        public async Task<int> AddUserTypeAsync(UserTypeRequest userTypeDto)
        {
            var userType = _mapper.Map<UserType>(userTypeDto);

            _dbContext.UserTypes.Add(userType);
            await _dbContext.SaveChangesAsync();

            return userType.Id;
        }

        public async Task<bool> UpdateUserTypeAsync(int userTypeId, UserTypeRequest userTypeDto)
        {
            var existingUserType = await _dbContext.UserTypes.FindAsync(userTypeId);

            if (existingUserType == null)
                return false;

            existingUserType.TypeName = userTypeDto.TypeName;

            _dbContext.UserTypes.Update(existingUserType);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteUserTypeAsync(int userTypeId)
        {
            var userType = await _dbContext.UserTypes.FindAsync(userTypeId);

            if (userType == null)
                return false;

            _dbContext.UserTypes.Remove(userType);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
