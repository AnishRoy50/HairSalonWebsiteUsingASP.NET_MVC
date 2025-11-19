namespace HairSalon.Models.DTOs
{
    /// <summary>
    /// Data Transfer Object for appointment data
    /// </summary>
    public class AppointmentDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string FullName => $"{FirstName} {LastName}";
    }
}
