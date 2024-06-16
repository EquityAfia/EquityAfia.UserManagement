using AutoMapper;
using EquityAfia.UserManagement.Application.Interfaces.UserRoleAndTypeRepositories;
using EquityAfia.UserManagement.Contracts.UserRoleAndTypeManagement.UserType;
using EquityAfia.UserManagement.Domain.RolesAndTypesAggregate.RolesAndTypesEntity;
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

        public async Task<List<UserType>> GetAllUserTypesAsync()
        {
            var userTypes = await _dbContext.UserTypes
                .ToListAsync();

            return userTypes;
        }

        public async Task<UserType> GetUserTypeByNameAsync(string userTypeName)
        {
            var userType = await _dbContext.UserTypes
                .Where(ut => ut.TypeName == userTypeName)
                .FirstOrDefaultAsync();

            return userType;
        }

        public async Task<UserType> GetUserTypeByIdAsync(int id)
        {
           var userType = await _dbContext.UserTypes
                .FirstOrDefaultAsync(ut => ut.Id == id);

            return userType;
        }

        public async Task<int> AddUserTypeAsync(UserType userType)
        {
            await _dbContext.UserTypes.AddAsync(userType);
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
