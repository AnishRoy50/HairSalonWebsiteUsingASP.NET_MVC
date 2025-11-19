using HairSalon.Models.DTOs;

namespace HairSalon.Core.Interfaces
{
    /// <summary>
    /// Service interface for appointment business logic
    /// </summary>
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync();
        Task<AppointmentDto?> GetAppointmentByIdAsync(int id);
        Task<AppointmentDto> CreateAppointmentAsync(CreateAppointmentDto createDto);
        Task UpdateAppointmentAsync(int id, UpdateAppointmentDto updateDto);
        Task DeleteAppointmentAsync(int id);
        Task<bool> AppointmentExistsAsync(int id);
    }
}
