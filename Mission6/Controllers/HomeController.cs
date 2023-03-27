using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission6.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Controllers
{
    public class HomeController : Controller
    {
    

        private MovieContext MovieContext { get; set; }

        public HomeController( MovieContext x)
        {
           
            MovieContext = x;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View("My Podcasts");
        }

        [HttpGet]
        public IActionResult NewMovies()
        {
            ViewBag.Categories = MovieContext.Categories.ToList();

            return View();
        }

        [HttpGet]
        public IActionResult Waitlist()
        {
            var movies = MovieContext.responses.Include(x => x.Category).OrderBy(x => x.Title).ToList();

            return View(movies);
        }

        [HttpPost]
        public IActionResult NewMovies(MovieResponse mr)
        {
            if (ModelState.IsValid)
            {
                MovieContext.Add(mr);
                MovieContext.SaveChanges();
                return View("Confirmation", mr);
            }
            else
            {
                ViewBag.Categories = MovieContext.Categories.ToList();
                return View(mr);
            }


        }

        [HttpGet]
        public IActionResult Edit (int movieid)
        {
            ViewBag.Categories = MovieContext.Categories.ToList();

            var movie = MovieContext.responses.Single(x => x.MovieID == movieid);

            return View("NewMovies", movie);
        }

        [HttpPost]
        public IActionResult Edit (MovieResponse mr, int movieid)
        {
            if (ModelState.IsValid)
            {
                MovieContext.Update(mr);
                MovieContext.SaveChanges();

                return RedirectToAction("Waitlist");
            }
            else
            {
                ViewBag.Categories = MovieContext.Categories.ToList();

                var movie = MovieContext.responses.Single(x => x.MovieID == movieid);

                return View("NewMovies", movie);
            }

        }

        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = MovieContext.responses.Single(x => x.MovieID == movieid);

            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(MovieResponse mr)
        {
            MovieContext.responses.Remove(mr);
            MovieContext.SaveChanges();

            return RedirectToAction("Waitlist");
        }
    }
}
