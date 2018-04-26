using System;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;
using System.Data.Entity;
using System.Linq;

namespace Vidly.Controllers.Api
{
    public class RentalsController : ApiController
    {

        private ApplicationDbContext _context;

        //data from database
        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }


        [HttpPost]
        public IHttpActionResult CreateNewRentals(RentalDto rentals)
        {


            //Get customer from the context(if we had to use it externally we would use SingleOrDefault)
            var customer = _context.Customers.Single(c => c.Id == rentals.CustomerId);


            //This is the same with SQL 
            //SELECT *
            //FROM Movies
            //WHERE Id IN (1,2,3)
            var movies = _context.Movies.Where(m => rentals.MovieIds.Contains(m.Id)).ToList() ;


            //Create a rental objectfor each movie
            foreach (var movie in movies)
            {
                if(movie.NumberAvailable == 0)
                {
                    return BadRequest("Movie is not available");
                }

                //Change availability so we will control if a movie is not available and all are rented
                movie.NumberAvailable--;

                var rental = new Rental
                {
                   
                   Customer = customer,
                   Movie = movie,
                   DateRent = DateTime.Now
                   

                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();
            return Ok();

        }

    }
}
