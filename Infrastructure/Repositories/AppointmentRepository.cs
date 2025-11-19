using HairSalon.Core.Interfaces;
using HairSalon.Data;
using HairSalon.Models;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Infrastructure.Repositories
{
    /// <summary>
    /// Repository implementation for appointment-specific operations
    /// </summary>
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(HairDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be null or empty.", nameof(email));
            }

            return await _dbSet
                .Where(a => a.Email.ToLower() == email.ToLower())
                .OrderByDescending(a => a.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetUpcomingAppointmentsAsync()
        {
            return await _dbSet
                .OrderBy(a => a.Id)
                .ToListAsync();
        }
    }
}
