using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EquityAfia.UserManagement.Domain.UserAggregate.UsersEntities;
using EquityAfia.UserManagement.Infrastructure.Data;
using EquityAfia.UserManagement.Application.Interfaces;

namespace EquityAfia.UserManagement.Infrastructure.Repositories
{
    public class PractitionerRepository : IPractitionerRepository
    {
        private readonly ApplicationDbContext _context;

        public PractitionerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Practitioner> GetPractitionerByIdAsync(Guid id)
        {
            try
            {
                return await _context.Practitioners
                    .Include(p => p.PractitionerTypes)
                    .FirstOrDefaultAsync(p => p.Id == id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An unexpected error occurred while getting practitioner by Id", ex);
            }
        }

        public async Task UpdatePractitionerAsync(Practitioner practitioner)
        {
            try
            {
                _context.Practitioners.Update(practitioner);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An unexpected error occurrednwhile updating practitioner", ex);
            }
        }
    }
}
