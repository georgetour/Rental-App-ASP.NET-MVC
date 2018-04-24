using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class RentalsController : Controller
    {

        private ApplicationDbContext _context;


        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Rentals
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult NewRental()
        {
            var customers = _context.Customers.ToList();
            var movies = _context.Movies.ToList();

            var viewModel = new RentalFormViewModel
            {
                Movie = movies,
                Customer = customers
            };

            return View();
        }

    }
}