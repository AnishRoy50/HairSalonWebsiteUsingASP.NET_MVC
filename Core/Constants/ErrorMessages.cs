namespace HairSalon.Core.Constants
{
    /// <summary>
    /// Centralized error messages for consistent user feedback
    /// </summary>
    public static class ErrorMessages
    {
        public const string AppointmentNotFound = "Appointment not found.";
        public const string AppointmentCreationFailed = "Failed to create appointment.";
        public const string AppointmentUpdateFailed = "Failed to update appointment.";
        public const string AppointmentDeletionFailed = "Failed to delete appointment.";
        public const string InvalidAppointmentData = "Invalid appointment data provided.";
        public const string DatabaseUnavailable = "Unable to connect to the database.";
        public const string UnexpectedError = "An unexpected error occurred. Please try again later.";
        public const string InvalidId = "Invalid ID provided.";
        public const string EntityNotFound = "Requested entity not found.";
    }
}
