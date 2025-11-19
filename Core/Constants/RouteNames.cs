namespace HairSalon.Core.Constants
{
    /// <summary>
    /// Centralized route names for consistent navigation
    /// </summary>
    public static class RouteNames
    {
        public const string DefaultRoute = "default";
        
        public static class Controllers
        {
            public const string Home = "Home";
            public const string Appointments = "Appointments";
        }
        
        public static class Actions
        {
            public const string Index = "Index";
            public const string Details = "Details";
            public const string Create = "Create";
            public const string Edit = "Edit";
            public const string Delete = "Delete";
            public const string AboutUs = "AboutUs";
            public const string Service = "Service";
            public const string Appointment = "Appointment";
            public const string Pricing = "Pricing";
            public const string Subscribe = "Subscribe";
            public const string Error = "Error";
        }
    }
}
