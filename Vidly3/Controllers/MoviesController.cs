using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly3.Models;
using Vidly3.ViewModels;

namespace Vidly3.Controllers
{
    public class MoviesController : Controller
    {
        public List<Movie> movies = new List<Movie>
        {
            new Movie { Name = "Shrek" },
            new Movie { Name = "Wall-e" }
        };

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult Index()
        {
            var movieViewModel = new MovieViewModel
            {
                Movies = movies
            };

            return View(movieViewModel);
        }
    }
}