using HairSalon.Core.Constants;
using HairSalon.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HairSalon.Controllers
{
    /// <summary>
    /// Controller for handling home and public pages
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Display the home page
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Display the About Us page
        /// </summary>
        public IActionResult AboutUs()
        {
            return View();
        }

        /// <summary>
        /// Display the Services page
        /// </summary>
        public IActionResult Service()
        {
            return View();
        }

        /// <summary>
        /// Display the Appointment booking page
        /// </summary>
        public IActionResult Appointment()
        {
            return View();
        }

        /// <summary>
        /// Display the Pricing page
        /// </summary>
        public IActionResult Pricing()
        {
            return View();
        }

        /// <summary>
        /// Display the Subscribe page
        /// </summary>
        public IActionResult Subscribe()
        {
            return View();
        }

        /// <summary>
        /// Display error page
        /// </summary>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var errorViewModel = new ErrorViewModel 
            { 
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier 
            };

            _logger.LogError("Error page displayed for RequestId: {RequestId}", errorViewModel.RequestId);
            
            return View(errorViewModel);
        }
    }
}