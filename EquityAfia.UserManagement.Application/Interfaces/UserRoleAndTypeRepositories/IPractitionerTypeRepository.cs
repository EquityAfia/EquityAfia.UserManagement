using EquityAfia.UserManagement.Contracts.UserRoleAndTypeManagementDTOs.PractitionerTypeDTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EquityAfia.UserManagement.Application.Interfaces.UserRoleAndTypeRepositories
{
    public interface IPractitionerTypeRepository
    {
        Task<List<PractitionerTypeRequest>> GetAllPractitionerTypesAsync();
        Task<PractitionerTypeRequest> GetPractitionerTypeByIdAsync(Guid practitionerTypeId);
        Task<Guid> AddPractitionerTypeAsync(PractitionerTypeRequest practitionerTypeDto);
        Task<bool> UpdatePractitionerTypeAsync(Guid practitionerTypeId, PractitionerTypeRequest practitionerTypeDto);
        Task<bool> DeletePractitionerTypeAsync(Guid practitionerTypeId);
    }
}
