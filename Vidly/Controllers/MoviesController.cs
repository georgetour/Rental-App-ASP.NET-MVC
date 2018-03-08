using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {


        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };
            var movie2 = new Movie { Name = "Wall-e" };

            var customers = new List<Customer>
            {
                new Customer() {Name = "Customer1" },
                new Customer() {Name = "Customer2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }


        public ActionResult Edit(int id)
        {
            return Content("id="+id);
        }

        //movies
        public ActionResult Index(int? pageIndex,string sortBy)
        {
           
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));

        }

        [Route("movies/released/{year}/{month:regex(\\d{2})}")]
        public ActionResult ByReleaseDate(int year,byte month)
        {
            return Content(year +"/" +month);
        }
    }
}