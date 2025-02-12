using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Mission6.Controllers
{
    // Set up navigation/connection between pages
    public class HomeController : Controller
    {
        private MovieFormContext _context;

        public HomeController(MovieFormContext logger)
        {
            _context = logger;
        }

        // Index/Home page
        public IActionResult Index()
        {
            return View();
        }

        // Form page
        [HttpGet]
        public IActionResult MovieForm()
        {
            return View("MovieForm");
        }

        // Get to know Joel page
        public IActionResult GettoKnowYou()
        {
            return View("GettoKnowYou");
        }

        // Movie Form page and confirmation page for submitting a film
        [HttpPost]
        public IActionResult MovieForm(Form response)
        {
            _context.Forms.Add(response);
            _context.SaveChanges();


            return View("Confirmation", response);
        }

    }
}
