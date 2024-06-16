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
            return await _context.Practitioners
                .Include(p => p.PractitionerTypes) 
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdatePractitionerAsync(Practitioner practitioner)
        {
            _context.Practitioners.Update(practitioner);
            await _context.SaveChangesAsync();
        }
    }
}
