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
            var movies = _context.Movies.Include(c => c.Genre).ToList();

            var movieViewModel = new MovieViewModel
            {
                Movies = movies
            };

            return View(movieViewModel);
        }

        [Route("Movies/Details/{movieId}")]
        public ActionResult Details(int movieId)
        {
            var movie = _context.Movies.Include(c => c.Genre).FirstOrDefault(m => m.Id == movieId);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }
    }
}