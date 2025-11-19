using HairSalon.Core.Constants;
using HairSalon.Core.Exceptions;
using HairSalon.Core.Interfaces;
using HairSalon.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairSalon.Controllers
{
    /// <summary>
    /// Controller for managing appointments
    /// </summary>
    [Authorize]
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly ILogger<AppointmentsController> _logger;

        public AppointmentsController(
            IAppointmentService appointmentService,
            ILogger<AppointmentsController> logger)
        {
            _appointmentService = appointmentService ?? throw new ArgumentNullException(nameof(appointmentService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            try
            {
                var appointments = await _appointmentService.GetAllAppointmentsAsync();
                return View(appointments);
            }
            catch (BusinessException ex)
            {
                _logger.LogError(ex, "Error loading appointments");
                TempData["ErrorMessage"] = ex.Message;
                return View(new List<AppointmentDto>());
            }
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest(ErrorMessages.InvalidId);
            }

            try
            {
                var appointment = await _appointmentService.GetAppointmentByIdAsync(id.Value);
                
                if (appointment == null)
                {
                    return NotFound(ErrorMessages.AppointmentNotFound);
                }

                return View(appointment);
            }
            catch (BusinessException ex)
            {
                _logger.LogError(ex, "Error loading appointment details for ID {Id}", id);
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            return View(new CreateAppointmentDto());
        }

        // POST: Appointments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAppointmentDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createDto);
            }

            try
            {
                await _appointmentService.CreateAppointmentAsync(createDto);
                TempData["SuccessMessage"] = "Appointment created successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (BusinessException ex)
            {
                _logger.LogError(ex, "Error creating appointment");
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(createDto);
            }
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest(ErrorMessages.InvalidId);
            }

            try
            {
                var appointment = await _appointmentService.GetAppointmentByIdAsync(id.Value);
                
                if (appointment == null)
                {
                    return NotFound(ErrorMessages.AppointmentNotFound);
                }

                var updateDto = new UpdateAppointmentDto
                {
                    FirstName = appointment.FirstName,
                    LastName = appointment.LastName,
                    Email = appointment.Email,
                    Password = string.Empty // Don't send password back to view
                };

                return View(updateDto);
            }
            catch (BusinessException ex)
            {
                _logger.LogError(ex, "Error loading appointment for editing with ID {Id}", id);
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Appointments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateAppointmentDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return View(updateDto);
            }

            try
            {
                await _appointmentService.UpdateAppointmentAsync(id, updateDto);
                TempData["SuccessMessage"] = "Appointment updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound(ErrorMessages.AppointmentNotFound);
            }
            catch (BusinessException ex)
            {
                _logger.LogError(ex, "Error updating appointment with ID {Id}", id);
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(updateDto);
            }
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest(ErrorMessages.InvalidId);
            }

            try
            {
                var appointment = await _appointmentService.GetAppointmentByIdAsync(id.Value);
                
                if (appointment == null)
                {
                    return NotFound(ErrorMessages.AppointmentNotFound);
                }

                return View(appointment);
            }
            catch (BusinessException ex)
            {
                _logger.LogError(ex, "Error loading appointment for deletion with ID {Id}", id);
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _appointmentService.DeleteAppointmentAsync(id);
                TempData["SuccessMessage"] = "Appointment deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound(ErrorMessages.AppointmentNotFound);
            }
            catch (BusinessException ex)
            {
                _logger.LogError(ex, "Error deleting appointment with ID {Id}", id);
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
