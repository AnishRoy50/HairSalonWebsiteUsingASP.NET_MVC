using HairSalon.Configuration;
using HairSalon.Core.Constants;
using HairSalon.Data;
using HairSalon.Middleware;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline
ConfigureMiddleware(app);

app.Run();

/// <summary>
/// Configure application services
/// </summary>
static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    // Add MVC
    services.AddControllersWithViews();

    // Configure database
    services.AddDatabaseConfiguration(configuration);

    // Configure Identity
    services.AddIdentityConfiguration()
        .AddEntityFrameworkStores<HairDbContext>();

    // Add application services (repositories, services, etc.)
    services.AddApplicationServices();

    // Add Razor Pages for Identity UI
    services.AddRazorPages();
}

/// <summary>
/// Configure middleware pipeline
/// </summary>
static void ConfigureMiddleware(WebApplication app)
{
    // Global exception handling
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandlingMiddleware();
        app.UseHsts();
    }
    else
    {
        app.UseDeveloperExceptionPage();
    }

    // Standard middleware
    app.UseHttpsRedirection();
    app.UseStaticFiles();

    // Routing
    app.UseRouting();

    // Authentication & Authorization
    app.UseAuthentication();
    app.UseAuthorization();

    // Map endpoints
    app.MapRazorPages();
    app.MapControllerRoute(
        name: RouteNames.DefaultRoute,
        pattern: "{controller=Home}/{action=Index}/{id?}");
}
