using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly3.Models;
using Vidly3.Dtos;

namespace Vidly3.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult AddRental(RentalDto newRental)
        {
            if (newRental.MovieIds.Count == 0)
                return BadRequest("No Movie Ids have been givens");

            var customer = _context.Customers.FirstOrDefault(c => c.Id == newRental.CustomerId);
            if (customer == null) return BadRequest("Invalid Customer Id.");

            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            foreach (var movieId in newRental.MovieIds)
            {
                var movie = movies.FirstOrDefault(m => m.Id == movieId);
                if (movie == null) return BadRequest("Invalid Movie Id.");

                if (movie.NumberAvailable < 1)
                {
                    return BadRequest("Movie is not available");
                }

                // Add Rental
                var rental = new Rental
                {
                    Customer = customer, 
                    Movie = movie, 
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);

                // Add Movie
                movie.NumberAvailable -= 1;
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}