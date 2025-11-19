using System.ComponentModel.DataAnnotations;

namespace HairSalon.Models.DTOs
{
    /// <summary>
    /// DTO for creating a new appointment
    /// </summary>
    public class CreateAppointmentDto
    {
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 255 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
