using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
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
            _context.Dispose();
        }


        //movies
        public ActionResult Index()
        {

            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);

        }

        //Details for one movie
        public ActionResult Details(int id)
        {

            var customerDetails = _context.Movies
                .Include(m => m.Genre)
                .SingleOrDefault(c => c.Id == id);

            if (customerDetails == null)
                return HttpNotFound();

            return View(customerDetails);
        }


        public ActionResult NewMovie()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm",viewModel);
        }

        public ActionResult Save(Movie movie)
        {
            movie.DateAdded = DateTime.Now;
            _context.Movies.Add(movie);

            _context.SaveChanges();


            return RedirectToAction("Index","Movies");
        }




    }
}