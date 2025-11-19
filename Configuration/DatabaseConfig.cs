using HairSalon.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Configuration
{
    /// <summary>
    /// Extension methods for configuring database services
    /// </summary>
    public static class DatabaseConfig
    {
        public static IServiceCollection AddDatabaseConfiguration(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            // Configure database context
            services.AddDbContext<HairDbContext>(options => 
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    sqlOptions => sqlOptions.MigrationsAssembly("HairSalon")
                ));

            return services;
        }
    }
}
