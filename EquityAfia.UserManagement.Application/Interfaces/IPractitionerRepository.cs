using System;
using System.Threading.Tasks;
using EquityAfia.UserManagement.Domain.UserAggregate.UsersEntities;

namespace EquityAfia.UserManagement.Application.Interfaces
{
    public interface IPractitionerRepository
    {
        Task<Practitioner> GetPractitionerByIdAsync(Guid id);
        Task UpdatePractitionerAsync(Practitioner practitioner);
    }
}
