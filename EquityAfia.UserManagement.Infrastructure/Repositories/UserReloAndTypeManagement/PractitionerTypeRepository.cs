using AutoMapper;
using EquityAfia.UserManagement.Application.Interfaces.UserRoleAndTypeRepositories;
using EquityAfia.UserManagement.Contracts.UserRoleAndTypeManagement.PractitionerType;
using EquityAfia.UserManagement.Domain.RolesAndTypesAggregate.RolesAndTypesEntity;
using EquityAfia.UserManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Infrastructure.Repositories.UserReloAndTypeManagement
{
    public class PractitionerTypeRepository : IPractitionerTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public PractitionerTypeRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<PractitionerTypeRequest>> GetAllPractitionerTypesAsync()
        {
            var practitionerTypes = await _dbContext.PractitionerTypes
                .Select(pt => _mapper.Map<PractitionerTypeRequest>(pt))
                .ToListAsync();

            return practitionerTypes;
        }

        public async Task<PractitionerTypeRequest> GetPractitionerTypeByIdAsync(Guid practitionerTypeId)
        {
            var practitionerType = await _dbContext.PractitionerTypes
                .Where(pt => pt.Id == practitionerTypeId)
                .FirstOrDefaultAsync();

            return _mapper.Map<PractitionerTypeRequest>(practitionerType);
        }

        public async Task<Guid> AddPractitionerTypeAsync(PractitionerTypeRequest practitionerTypeDto)
        {
            var practitionerType = _mapper.Map<PractitionerType>(practitionerTypeDto);

            _dbContext.PractitionerTypes.Add(practitionerType);
            await _dbContext.SaveChangesAsync();

            return practitionerType.Id;
        }

        public async Task<bool> UpdatePractitionerTypeAsync(Guid practitionerTypeId, PractitionerTypeRequest practitionerTypeDto)
        {
            var existingPractitionerType = await _dbContext.PractitionerTypes.FindAsync(practitionerTypeId);

            if (existingPractitionerType == null)
                return false;

            existingPractitionerType.TypeName = practitionerTypeDto.TypeName;

            _dbContext.PractitionerTypes.Update(existingPractitionerType);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeletePractitionerTypeAsync(Guid practitionerTypeId)
        {
            var practitionerType = await _dbContext.PractitionerTypes.FindAsync(practitionerTypeId);

            if (practitionerType == null)
                return false;

            _dbContext.PractitionerTypes.Remove(practitionerType);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
