using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly3.Models;
using Vidly3.ViewModels;
using System.Data.Entity;

namespace Vidly3.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }

        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("List");
            }

            return View("ReadOnlyList");
        }

        [Route("Movies/Details/{movieId}")]
        public ActionResult Details(int movieId)
        {
            var movie = _context.Movies.Include(c => c.Genre).FirstOrDefault(m => m.Id == movieId);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var movieFormViewModel = new MovieFormViewModel
            {
                Genres = _context.Genres
            };

            return View("MovieForm", movieFormViewModel);
        }

        [Route("Movies/Edit/{movieId}")]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int movieId)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == movieId);

            if (movie == null)
                return HttpNotFound();

            var movieFormViewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", movieFormViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var movieView = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", movieView);
            }

            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieRead = _context.Movies.First(m => m.Id == movie.Id);

                movieRead.Name = movie.Name;
                movieRead.ReleaseDate = movie.ReleaseDate;
                movieRead.GenreId = movie.GenreId;
                movieRead.NumberOfStock = movie.NumberOfStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}