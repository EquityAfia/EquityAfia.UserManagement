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
            try
            {
                var userTypes = await _dbContext.UserTypes
                    .ToListAsync();

                return userTypes;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An unexpected error occurred when getting ass user types", ex);
            }
        }

        public async Task<UserType> GetUserTypeByNameAsync(string userTypeName)
        {
            try
            {
                var userType = await _dbContext.UserTypes
                    .Where(ut => ut.TypeName == userTypeName)
                    .FirstOrDefaultAsync();

                return userType;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An unexpected error occurred while getting user type by name", ex);
            }
        }

        public async Task<UserType> GetUserTypeByIdAsync(int id)
        {
            try
            {
                var userType = await _dbContext.UserTypes
                     .FirstOrDefaultAsync(ut => ut.Id == id);

                return userType;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An unexpected error occurred while getting user type by Id", ex);
            }
        }

        public async Task<int> AddUserTypeAsync(UserType userType)
        {
            try
            {
                await _dbContext.UserTypes.AddAsync(userType);
                await _dbContext.SaveChangesAsync();

                return userType.Id;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An unexpected error occurred while adding a user type", ex);
            }
        }

        public async Task<bool> UpdateUserTypeAsync(int userTypeId, UserTypeRequest userTypeDto)
        {
            try
            {
                var existingUserType = await _dbContext.UserTypes.FindAsync(userTypeId);

                if (existingUserType == null)
                    return false;

                existingUserType.TypeName = userTypeDto.TypeName;

                _dbContext.UserTypes.Update(existingUserType);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An unexpected error occurred while updating user type", ex);
            }
        }

        public async Task<bool> DeleteUserTypeAsync(int userTypeId)
        {
            try
            {
                var userType = await _dbContext.UserTypes.FindAsync(userTypeId);

                if (userType == null)
                    return false;

                _dbContext.UserTypes.Remove(userType);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An unexpected error occurred while deleting user type", ex);
            }
        }

       
    }
}
