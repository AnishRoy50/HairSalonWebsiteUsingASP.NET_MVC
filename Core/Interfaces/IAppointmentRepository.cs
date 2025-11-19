using HairSalon.Models;

namespace HairSalon.Core.Interfaces
{
    /// <summary>
    /// Repository interface for appointment-specific operations
    /// </summary>
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task<IEnumerable<Appointment>> GetAppointmentsByEmailAsync(string email);
        Task<IEnumerable<Appointment>> GetUpcomingAppointmentsAsync();
    }
}
