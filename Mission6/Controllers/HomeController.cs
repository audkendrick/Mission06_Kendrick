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

        //// Form page
        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("MovieForm", new Movies());
        }

        // Get to know Joel page
        public IActionResult GettoKnowYou()
        {
            return View("GettoKnowYou");
        }

        //Movie Form page and confirmation page for submitting a film
        [HttpPost]
        public IActionResult MovieForm(Movies response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();


                return View("Confirmation", response);
            }
            else //Invalid data
            {
                ViewBag.Movies = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View(response);
            }
        }

        // Movie List page (database)
        public IActionResult MovieList()
        {
            //Linq
            var applications = _context.Movies
                .Include(x => x.Category) //.Include is how bring in foreign key relationship
                .OrderBy(x => x.Title).ToList();

            return View(applications);
        }

        // Editing a movie record
        [HttpGet]
        public IActionResult Edit(int id)
        {

            var recordEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View("MovieForm", recordEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movies updateInfo)
        {
            _context.Update(updateInfo);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }

        // Deleting a movie record
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordDelete); //Confirm the deletion
        }

        [HttpPost]
        public IActionResult Delete(Movies application)
        {
            _context.Movies.Remove(application);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }

    }
}
