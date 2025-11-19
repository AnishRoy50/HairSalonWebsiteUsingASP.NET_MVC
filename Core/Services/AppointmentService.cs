using HairSalon.Core.Constants;
using HairSalon.Core.Exceptions;
using HairSalon.Core.Interfaces;
using HairSalon.Models;
using HairSalon.Models.DTOs;
using Microsoft.Extensions.Logging;

namespace HairSalon.Core.Services
{
    /// <summary>
    /// Service implementation for appointment business logic
    /// </summary>
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ILogger<AppointmentService> _logger;

        public AppointmentService(
            IAppointmentRepository appointmentRepository,
            ILogger<AppointmentService> logger)
        {
            _appointmentRepository = appointmentRepository ?? throw new ArgumentNullException(nameof(appointmentRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync()
        {
            try
            {
                var appointments = await _appointmentRepository.GetAllAsync();
                return appointments.Select(MapToDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving all appointments");
                throw new BusinessException(ErrorMessages.DatabaseUnavailable, ex);
            }
        }

        public async Task<AppointmentDto?> GetAppointmentByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(ErrorMessages.InvalidId, nameof(id));
            }

            try
            {
                var appointment = await _appointmentRepository.GetByIdAsync(id);
                return appointment == null ? null : MapToDto(appointment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving appointment with ID {Id}", id);
                throw new BusinessException(ErrorMessages.DatabaseUnavailable, ex);
            }
        }

        public async Task<AppointmentDto> CreateAppointmentAsync(CreateAppointmentDto createDto)
        {
            if (createDto == null)
            {
                throw new ArgumentNullException(nameof(createDto));
            }

            ValidateAppointmentData(createDto.FirstName, createDto.LastName, createDto.Email);

            try
            {
                var appointment = new Appointment
                {
                    FirstName = createDto.FirstName.Trim(),
                    LastName = createDto.LastName.Trim(),
                    Email = createDto.Email.Trim().ToLower(),
                    Password = createDto.Password // Note: Should be hashed in production
                };

                await _appointmentRepository.AddAsync(appointment);
                await _appointmentRepository.SaveChangesAsync();

                _logger.LogInformation("Created new appointment with ID {Id}", appointment.Id);
                return MapToDto(appointment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating appointment");
                throw new BusinessException(ErrorMessages.AppointmentCreationFailed, ex);
            }
        }

        public async Task UpdateAppointmentAsync(int id, UpdateAppointmentDto updateDto)
        {
            if (id <= 0)
            {
                throw new ArgumentException(ErrorMessages.InvalidId, nameof(id));
            }

            if (updateDto == null)
            {
                throw new ArgumentNullException(nameof(updateDto));
            }

            ValidateAppointmentData(updateDto.FirstName, updateDto.LastName, updateDto.Email);

            try
            {
                var appointment = await _appointmentRepository.GetByIdAsync(id);
                if (appointment == null)
                {
                    throw new NotFoundException(nameof(Appointment), id);
                }

                appointment.FirstName = updateDto.FirstName.Trim();
                appointment.LastName = updateDto.LastName.Trim();
                appointment.Email = updateDto.Email.Trim().ToLower();
                appointment.Password = updateDto.Password; // Note: Should be hashed in production

                await _appointmentRepository.UpdateAsync(appointment);
                await _appointmentRepository.SaveChangesAsync();

                _logger.LogInformation("Updated appointment with ID {Id}", id);
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating appointment with ID {Id}", id);
                throw new BusinessException(ErrorMessages.AppointmentUpdateFailed, ex);
            }
        }

        public async Task DeleteAppointmentAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(ErrorMessages.InvalidId, nameof(id));
            }

            try
            {
                var appointment = await _appointmentRepository.GetByIdAsync(id);
                if (appointment == null)
                {
                    throw new NotFoundException(nameof(Appointment), id);
                }

                await _appointmentRepository.DeleteAsync(appointment);
                await _appointmentRepository.SaveChangesAsync();

                _logger.LogInformation("Deleted appointment with ID {Id}", id);
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting appointment with ID {Id}", id);
                throw new BusinessException(ErrorMessages.AppointmentDeletionFailed, ex);
            }
        }

        public async Task<bool> AppointmentExistsAsync(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            try
            {
                return await _appointmentRepository.ExistsAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while checking if appointment exists with ID {Id}", id);
                throw new BusinessException(ErrorMessages.DatabaseUnavailable, ex);
            }
        }

        private static void ValidateAppointmentData(string firstName, string lastName, string email)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("First name is required.", nameof(firstName));
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Last name is required.", nameof(lastName));
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email is required.", nameof(email));
            }

            if (!IsValidEmail(email))
            {
                throw new ArgumentException("Invalid email format.", nameof(email));
            }
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private static AppointmentDto MapToDto(Appointment appointment)
        {
            return new AppointmentDto
            {
                Id = appointment.Id,
                FirstName = appointment.FirstName,
                LastName = appointment.LastName,
                Email = appointment.Email
            };
        }
    }
}
