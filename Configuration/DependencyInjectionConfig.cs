using HairSalon.Core.Interfaces;
using HairSalon.Core.Services;
using HairSalon.Infrastructure.Repositories;

namespace HairSalon.Configuration
{
    /// <summary>
    /// Extension methods for configuring dependency injection
    /// </summary>
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();

            // Register services
            services.AddScoped<IAppointmentService, AppointmentService>();

            return services;
        }
    }
}
