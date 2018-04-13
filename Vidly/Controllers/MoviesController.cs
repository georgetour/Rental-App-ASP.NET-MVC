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
        //Return movies list according to user role
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");

            else
                return View("ReadOnlyList");


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

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult NewMovie()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm",viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            var viewModel = new MovieFormViewModel(movie)
            {
             
                Genres = _context.Genres.ToList()

            };
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View("MovieForm",viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
           
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.Genre = movie.Genre;
                movieInDb.Stock = movie.Stock;
                
            }

            _context.SaveChanges();


            return RedirectToAction("Index","Movies");
        }




    }
}